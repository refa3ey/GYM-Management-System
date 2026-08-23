using GYM_Desktop_app.Helpers;
using GYM_Desktop_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace GYM_Desktop_app.Database
{
    // ============================================================
    //  GYM PRO data layer  -  SQLite (embedded, no server needed)
    // ============================================================
    public static class DatabaseHelper
    {
        private static string _dbPath;

        public static void SetDatabasePath(string path) => _dbPath = path;

        private static string ConnString =>
            $"Data Source={_dbPath};Version=3;Foreign Keys=True;";

        public static SQLiteConnection GetConnection() => new SQLiteConnection(ConnString);

        private static string Now() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

        private static DateTime ParseDate(object o)
        {
            if (o == null || o == DBNull.Value) return DateTime.Now;
            return DateTime.TryParse(o.ToString(), out var d) ? d : DateTime.Now;
        }

        private static void Exec(SQLiteConnection c, string sql)
        {
            using (var cmd = new SQLiteCommand(sql, c)) cmd.ExecuteNonQuery();
        }

        // ===== SCHEMA + SEED =====
        public static void EnsureSchema()
        {
            if (string.IsNullOrEmpty(_dbPath))
                throw new InvalidOperationException("Database path not set.");

            using (var c = GetConnection())
            {
                c.Open();
                Exec(c, @"CREATE TABLE IF NOT EXISTS Users(
                            UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT UNIQUE, Password TEXT, Role TEXT);");
                Exec(c, @"CREATE TABLE IF NOT EXISTS MembershipPlans(
                            PlanID INTEGER PRIMARY KEY AUTOINCREMENT,
                            PlanName TEXT, DurationMonths INTEGER, Price REAL);");
                Exec(c, @"CREATE TABLE IF NOT EXISTS Trainers(
                            TrainerID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT, Specialty TEXT, Phone TEXT);");
                Exec(c, @"CREATE TABLE IF NOT EXISTS Members(
                            MemberID INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserID INTEGER, Name TEXT, Phone TEXT, Age INTEGER,
                            Address TEXT, JoinDate TEXT, PlanID INTEGER, MembershipExpiry TEXT);");
                Exec(c, @"CREATE TABLE IF NOT EXISTS Payments(
                            PaymentID INTEGER PRIMARY KEY AUTOINCREMENT,
                            MemberID INTEGER, PlanID INTEGER, Amount REAL, Date TEXT, Method TEXT);");
                // migrate older DBs that predate the PlanID column
                try { Exec(c, "ALTER TABLE Payments ADD COLUMN PlanID INTEGER"); } catch { }
                Exec(c, @"CREATE TABLE IF NOT EXISTS Attendance(
                            AttendanceID INTEGER PRIMARY KEY AUTOINCREMENT,
                            MemberID INTEGER NOT NULL, CheckInTime TEXT NOT NULL,
                            CheckOutTime TEXT NULL, Notes TEXT NULL);");
            }
            SeedAdmin();
            SeedPlans();
        }

        public static void EnsureAttendanceTable() { /* handled by EnsureSchema */ }

        // ===== PASSWORD HASHING =====
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash) || !hash.StartsWith("$2")) return false;
            try { return BCrypt.Net.BCrypt.Verify(password, hash); }
            catch { return false; }
        }

        // ===== SEED =====
        public static void SeedAdmin()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Role='Admin'", conn))
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return;
                using (var ins = new SQLiteCommand(
                    "INSERT INTO Users (Username, Password, Role) VALUES ('admin', @p, 'Admin')", conn))
                {
                    ins.Parameters.AddWithValue("@p", HashPassword("admin123"));
                    ins.ExecuteNonQuery();
                }
            }
        }

        public static void SeedPlans()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM MembershipPlans", conn))
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return;
                string insert = @"INSERT INTO MembershipPlans (PlanName, DurationMonths, Price) VALUES
                    ('Monthly Plan', 1, 30.00),
                    ('Quarterly Plan', 3, 80.00),
                    ('Semi-Annual Plan', 6, 150.00),
                    ('Annual Plan', 12, 250.00)";
                using (var cmd = new SQLiteCommand(insert, conn)) cmd.ExecuteNonQuery();
            }
        }

        public static void SeedInitialData() { SeedAdmin(); SeedPlans(); }

        // ===== USERS / AUTH =====
        public static User ValidateUser(string username, string password)
        {
            int userId = 0; string storedPassword = null; string role = null;
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Users WHERE Username=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read())
                        {
                            userId = Convert.ToInt32(r["UserID"]);
                            storedPassword = r["Password"].ToString();
                            role = r["Role"].ToString();
                        }
                }
            }
            if (storedPassword == null) return null;

            bool ok = false;
            if (VerifyPassword(password, storedPassword)) ok = true;
            else if (storedPassword == password) { UpdateUserPassword(userId, HashPassword(password)); ok = true; }
            if (!ok) return null;

            // Member login only valid while the member record exists (no ghost logins)
            if (string.Equals(role, "Member", StringComparison.OrdinalIgnoreCase) && !MemberExistsForUser(userId))
                return null;

            return new User { UserID = userId, Username = username, Role = role };
        }

        private static bool MemberExistsForUser(int userId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Members WHERE UserID=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", userId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static void UpdateUserPassword(int userId, string newHashedPassword)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Users SET Password=@p WHERE UserID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@p", newHashedPassword);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool VerifyUserPassword(string username, string password)
            => ValidateUser(username, password) != null;

        // ===== MEMBERS =====
        public static bool MemberExists(string name, string phone)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Members WHERE TRIM(Name)=@n AND IFNULL(TRIM(Phone),'')=@p", conn))
                {
                    cmd.Parameters.AddWithValue("@n", (name ?? "").Trim());
                    cmd.Parameters.AddWithValue("@p", (phone ?? "").Trim());
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static List<Member> GetAllMembers()
        {
            var list = new List<Member>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Members", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(ReadMember(r));
            }
            return list;
        }

        public static void AddMember(Member m, string username, string password)
        {
            if (MemberExists(m.Name, m.Phone))
                throw new InvalidOperationException(
                    $"A member named \"{m.Name}\" with phone \"{m.Phone}\" already exists.");

            password = HashPassword(password);
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    long userID;
                    using (var cmd = new SQLiteCommand(
                        "INSERT INTO Users (Username, Password, Role) VALUES (@u,@p,'Member'); SELECT last_insert_rowid();", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        userID = (long)cmd.ExecuteScalar();
                    }
                    using (var cmd = new SQLiteCommand(
                        @"INSERT INTO Members (UserID, Name, Phone, Age, Address, JoinDate, PlanID, MembershipExpiry)
                          VALUES (@uid,@name,@phone,@age,@addr,@join,@plan,@expiry)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@uid", userID);
                        cmd.Parameters.AddWithValue("@name", m.Name);
                        cmd.Parameters.AddWithValue("@phone", m.Phone ?? "");
                        cmd.Parameters.AddWithValue("@age", m.Age);
                        cmd.Parameters.AddWithValue("@addr", m.Address ?? "");
                        cmd.Parameters.AddWithValue("@join", Fmt(m.JoinDate));
                        cmd.Parameters.AddWithValue("@plan", m.PlanID);
                        cmd.Parameters.AddWithValue("@expiry", Fmt(m.MembershipExpiry));
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
            }
        }

        public static void UpdateMember(Member m)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    @"UPDATE Members SET Name=@name, Phone=@phone, Age=@age, Address=@addr,
                        PlanID=@plan, MembershipExpiry=@expiry WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@name", m.Name);
                    cmd.Parameters.AddWithValue("@phone", m.Phone ?? "");
                    cmd.Parameters.AddWithValue("@age", m.Age);
                    cmd.Parameters.AddWithValue("@addr", m.Address ?? "");
                    cmd.Parameters.AddWithValue("@plan", m.PlanID);
                    cmd.Parameters.AddWithValue("@expiry", Fmt(m.MembershipExpiry));
                    cmd.Parameters.AddWithValue("@id", m.MemberID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMember(int memberID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    int userID = 0;
                    using (var cmd = new SQLiteCommand("SELECT UserID FROM Members WHERE MemberID=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", memberID);
                        var r = cmd.ExecuteScalar();
                        if (r != null && r != DBNull.Value) userID = Convert.ToInt32(r);
                    }
                    foreach (var sql in new[]
                    {
                        "DELETE FROM Attendance WHERE MemberID=@id",
                        "DELETE FROM Payments WHERE MemberID=@id",
                        "DELETE FROM Members WHERE MemberID=@id"
                    })
                        using (var cmd = new SQLiteCommand(sql, conn, tx))
                        { cmd.Parameters.AddWithValue("@id", memberID); cmd.ExecuteNonQuery(); }

                    if (userID > 0)
                        using (var cmd = new SQLiteCommand("DELETE FROM Users WHERE UserID=@u", conn, tx))
                        { cmd.Parameters.AddWithValue("@u", userID); cmd.ExecuteNonQuery(); }

                    tx.Commit();
                }
            }
        }

        public static Member FindMember(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            input = QRHelper.ParseQRContent(input.Trim());
            if (!int.TryParse(input, out int memberID) || memberID <= 0) return null;

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Members WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read()) return ReadMember(r);
                }
            }
            return null;
        }

        public static List<Member> FindMembers(string search)
        {
            var list = new List<Member>();
            if (string.IsNullOrWhiteSpace(search)) return list;

            string parsed = QRHelper.ParseQRContent(search.Trim());
            if (int.TryParse(parsed, out int memberID) && memberID > 0)
            {
                var m = FindMember(search);
                if (m != null) list.Add(m);
                return list;
            }
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT * FROM Members WHERE Name LIKE @s OR Phone LIKE @s", conn))
                {
                    cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(ReadMember(r));
                }
            }
            return list;
        }

        public static Member GetMemberByUserID(int userID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Members WHERE UserID=@uid", conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userID);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read()) return ReadMember(r);
                }
            }
            return null;
        }

        private static Member ReadMember(IDataRecord r) => new Member
        {
            MemberID = Convert.ToInt32(r["MemberID"]),
            UserID = r["UserID"] != DBNull.Value ? Convert.ToInt32(r["UserID"]) : 0,
            Name = r["Name"].ToString(),
            Phone = r["Phone"]?.ToString(),
            Age = r["Age"] != DBNull.Value ? Convert.ToInt32(r["Age"]) : 0,
            Address = r["Address"]?.ToString(),
            JoinDate = ParseDate(r["JoinDate"]),
            PlanID = r["PlanID"] != DBNull.Value ? Convert.ToInt32(r["PlanID"]) : 0,
            MembershipExpiry = ParseDate(r["MembershipExpiry"])
        };

        // ===== PLANS =====
        public static List<MembershipPlan> GetAllPlans()
        {
            var list = new List<MembershipPlan>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM MembershipPlans", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new MembershipPlan
                        {
                            PlanID = Convert.ToInt32(r["PlanID"]),
                            PlanName = r["PlanName"].ToString(),
                            DurationMonths = Convert.ToInt32(r["DurationMonths"]),
                            Price = Convert.ToDecimal(r["Price"])
                        });
            }
            return list;
        }

        public static void AddPlan(MembershipPlan p)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO MembershipPlans (PlanName, DurationMonths, Price) VALUES (@n,@d,@p)", conn))
                {
                    cmd.Parameters.AddWithValue("@n", p.PlanName);
                    cmd.Parameters.AddWithValue("@d", p.DurationMonths);
                    cmd.Parameters.AddWithValue("@p", p.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePlan(MembershipPlan p)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE MembershipPlans SET PlanName=@n, DurationMonths=@d, Price=@p WHERE PlanID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@n", p.PlanName);
                    cmd.Parameters.AddWithValue("@d", p.DurationMonths);
                    cmd.Parameters.AddWithValue("@p", p.Price);
                    cmd.Parameters.AddWithValue("@id", p.PlanID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletePlan(int planID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM MembershipPlans WHERE PlanID=@id", conn))
                { cmd.Parameters.AddWithValue("@id", planID); cmd.ExecuteNonQuery(); }
            }
        }

        public static string GetPlanNameByID(int planID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT PlanName FROM MembershipPlans WHERE PlanID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", planID);
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? result.ToString() : "Member";
                }
            }
        }

        // ===== TRAINERS =====
        public static List<Trainer> GetAllTrainers()
        {
            var list = new List<Trainer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Trainers", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Trainer
                        {
                            TrainerID = Convert.ToInt32(r["TrainerID"]),
                            Name = r["Name"].ToString(),
                            Specialty = r["Specialty"]?.ToString(),
                            Phone = r["Phone"]?.ToString()
                        });
            }
            return list;
        }

        public static void AddTrainer(Trainer t)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Trainers (Name, Specialty, Phone) VALUES (@n,@s,@p)", conn))
                {
                    cmd.Parameters.AddWithValue("@n", t.Name);
                    cmd.Parameters.AddWithValue("@s", t.Specialty ?? "");
                    cmd.Parameters.AddWithValue("@p", t.Phone ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTrainer(int trainerID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Trainers WHERE TrainerID=@id", conn))
                { cmd.Parameters.AddWithValue("@id", trainerID); cmd.ExecuteNonQuery(); }
            }
        }

        // ===== PAYMENTS =====
        public static void AddPayment(Payment p)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Payments (MemberID, PlanID, Amount, Date, Method) VALUES (@m,@plan,@a,@d,@meth)", conn))
                {
                    cmd.Parameters.AddWithValue("@m", p.MemberID);
                    cmd.Parameters.AddWithValue("@plan", p.PlanID);
                    cmd.Parameters.AddWithValue("@a", p.Amount);
                    cmd.Parameters.AddWithValue("@d", Fmt(p.Date == default(DateTime) ? DateTime.Now : p.Date));
                    cmd.Parameters.AddWithValue("@meth", p.Method ?? "Cash");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetPaymentsReport()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT p.PaymentID, m.Name AS MemberName,
                                      COALESCE(pl.PlanName, '-') AS Plan,
                                      p.Amount, p.Date, p.Method
                               FROM Payments p
                               JOIN Members m ON p.MemberID=m.MemberID
                               LEFT JOIN MembershipPlans pl ON pl.PlanID=p.PlanID
                               ORDER BY p.Date DESC";
                using (var adapter = new SQLiteDataAdapter(sql, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // ===== ATTENDANCE =====
        public static bool IsMembershipValid(int memberID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT MembershipExpiry FROM Members WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return false;
                    return ParseDate(result) > DateTime.Now;
                }
            }
        }

        public static int GetTodayCheckInCount()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Attendance WHERE date(CheckInTime)=date('now','localtime')", conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int CheckInMember(int memberID, string notes = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Attendance (MemberID, CheckInTime, Notes) VALUES (@mid,@time,@notes); SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@mid", memberID);
                    cmd.Parameters.AddWithValue("@time", Now());
                    cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void CheckOutMember(int attendanceID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Attendance SET CheckOutTime=@time WHERE AttendanceID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@time", Now());
                    cmd.Parameters.AddWithValue("@id", attendanceID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Attendance GetOpenCheckIn(int memberID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT a.AttendanceID, a.MemberID, m.Name, a.CheckInTime, a.CheckOutTime, a.Notes
                               FROM Attendance a JOIN Members m ON a.MemberID=m.MemberID
                               WHERE a.MemberID=@mid AND a.CheckOutTime IS NULL";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mid", memberID);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read()) return ReadAttendance(r);
                }
            }
            return null;
        }

        public static List<Attendance> GetTodayAttendance()
        {
            var list = new List<Attendance>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT a.AttendanceID, a.MemberID, m.Name, a.CheckInTime, a.CheckOutTime, a.Notes
                               FROM Attendance a JOIN Members m ON a.MemberID=m.MemberID
                               WHERE date(a.CheckInTime)=date('now','localtime')
                               ORDER BY a.CheckInTime DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(ReadAttendance(r));
            }
            return list;
        }

        public static List<Attendance> GetAttendanceByDateRange(DateTime from, DateTime to, int? memberID = null)
        {
            var list = new List<Attendance>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT a.AttendanceID, a.MemberID, m.Name, a.CheckInTime, a.CheckOutTime, a.Notes
                               FROM Attendance a JOIN Members m ON a.MemberID=m.MemberID
                               WHERE a.CheckInTime >= @from AND a.CheckInTime < @to";
                if (memberID.HasValue) sql += " AND a.MemberID=@mid";
                sql += " ORDER BY a.CheckInTime DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@from", Fmt(from.Date));
                    cmd.Parameters.AddWithValue("@to", Fmt(to.Date.AddDays(1)));
                    if (memberID.HasValue) cmd.Parameters.AddWithValue("@mid", memberID.Value);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(ReadAttendance(r));
                }
            }
            return list;
        }

        public static (int today, int week, int month) GetAttendanceStats()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT
                    SUM(CASE WHEN date(CheckInTime)=date('now','localtime') THEN 1 ELSE 0 END) AS Today,
                    SUM(CASE WHEN CheckInTime >= datetime('now','localtime','-7 days')  THEN 1 ELSE 0 END) AS Week,
                    SUM(CASE WHEN CheckInTime >= datetime('now','localtime','-30 days') THEN 1 ELSE 0 END) AS Month
                    FROM Attendance";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    if (r.Read())
                        return (
                            r["Today"] != DBNull.Value ? Convert.ToInt32(r["Today"]) : 0,
                            r["Week"] != DBNull.Value ? Convert.ToInt32(r["Week"]) : 0,
                            r["Month"] != DBNull.Value ? Convert.ToInt32(r["Month"]) : 0);
            }
            return (0, 0, 0);
        }

        private static Attendance ReadAttendance(IDataRecord r) => new Attendance
        {
            AttendanceID = Convert.ToInt32(r["AttendanceID"]),
            MemberID = Convert.ToInt32(r["MemberID"]),
            MemberName = r["Name"].ToString(),
            CheckInTime = ParseDate(r["CheckInTime"]),
            CheckOutTime = r["CheckOutTime"] != DBNull.Value ? (DateTime?)ParseDate(r["CheckOutTime"]) : null,
            Notes = r["Notes"] != DBNull.Value ? r["Notes"].ToString() : null
        };

        // ===== ANALYTICS =====
        public static List<(string Month, decimal Total)> GetMonthlyRevenue(int monthsBack = 12)
        {
            var result = new List<(string, decimal)>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string start = Fmt(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-(monthsBack - 1)));
                using (var cmd = new SQLiteCommand(
                    "SELECT strftime('%Y-%m', Date) AS M, SUM(Amount) AS Total FROM Payments WHERE Date>=@s GROUP BY M ORDER BY M", conn))
                {
                    cmd.Parameters.AddWithValue("@s", start);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            var ym = r["M"].ToString();
                            var label = DateTime.TryParse(ym + "-01", out var d) ? d.ToString("MMM yyyy") : ym;
                            result.Add((label, Convert.ToDecimal(r["Total"])));
                        }
                }
            }
            return result;
        }

        public static List<(string Month, int Count)> GetMemberGrowth(int monthsBack = 12)
        {
            var perMonth = new Dictionary<string, int>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT strftime('%Y-%m', JoinDate) AS M, COUNT(*) AS C FROM Members WHERE JoinDate IS NOT NULL GROUP BY M", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) perMonth[r["M"].ToString()] = Convert.ToInt32(r["C"]);
            }
            var result = new List<(string, int)>();
            var start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-(monthsBack - 1));
            int cumulative = 0;
            foreach (var kv in perMonth)
                if (DateTime.TryParse(kv.Key + "-01", out var d) && d < start) cumulative += kv.Value;
            for (int i = 0; i < monthsBack; i++)
            {
                var month = start.AddMonths(i);
                if (perMonth.TryGetValue(month.ToString("yyyy-MM"), out int n)) cumulative += n;
                result.Add((month.ToString("MMM yyyy"), cumulative));
            }
            return result;
        }

        public static List<(string PlanName, int Count)> GetPlanDistribution()
        {
            var result = new List<(string, int)>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT p.PlanName, COUNT(m.MemberID) AS C
                               FROM MembershipPlans p LEFT JOIN Members m ON m.PlanID=p.PlanID
                               GROUP BY p.PlanID HAVING COUNT(m.MemberID)>0 ORDER BY C DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) result.Add((r["PlanName"].ToString(), Convert.ToInt32(r["C"])));
            }
            return result;
        }

        public static List<(string Method, decimal Total)> GetPaymentMethodBreakdown()
        {
            var result = new List<(string, decimal)>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT IFNULL(Method,'Unknown') AS Method, SUM(Amount) AS Total FROM Payments GROUP BY Method ORDER BY Total DESC", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) result.Add((r["Method"].ToString(), Convert.ToDecimal(r["Total"])));
            }
            return result;
        }

        public static List<(int Hour, int CheckIns)> GetPeakHours()
        {
            var result = new List<(int, int)>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT CAST(strftime('%H', CheckInTime) AS INTEGER) AS Hr, COUNT(*) AS C FROM Attendance GROUP BY Hr ORDER BY Hr", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) result.Add((Convert.ToInt32(r["Hr"]), Convert.ToInt32(r["C"])));
            }
            return result;
        }

        public static (int totalMembers, int activeMembers, decimal monthRevenue,
                        int weekCheckIns, decimal yearRevenue, int newThisMonth) GetDashboardStats()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string now = Now();
                string monthStart = Fmt(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
                string yearStart = Fmt(new DateTime(DateTime.Now.Year, 1, 1));
                string weekAgo = Fmt(DateTime.Now.AddDays(-7));

                int total = ScalarInt(conn, "SELECT COUNT(*) FROM Members");
                int active = ScalarInt(conn, "SELECT COUNT(*) FROM Members WHERE MembershipExpiry>=@d", ("@d", now));
                decimal monthRev = ScalarDec(conn, "SELECT IFNULL(SUM(Amount),0) FROM Payments WHERE Date>=@d", ("@d", monthStart));
                int weekChk = ScalarInt(conn, "SELECT COUNT(*) FROM Attendance WHERE CheckInTime>=@d", ("@d", weekAgo));
                decimal yearRev = ScalarDec(conn, "SELECT IFNULL(SUM(Amount),0) FROM Payments WHERE Date>=@d", ("@d", yearStart));
                int newMonth = ScalarInt(conn, "SELECT COUNT(*) FROM Members WHERE JoinDate>=@d", ("@d", monthStart));
                return (total, active, monthRev, weekChk, yearRev, newMonth);
            }
        }

        // ===== helpers =====
        private static int ScalarInt(SQLiteConnection conn, string sql, params (string, object)[] ps)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                foreach (var (k, v) in ps) cmd.Parameters.AddWithValue(k, v);
                var r = cmd.ExecuteScalar();
                return (r == null || r == DBNull.Value) ? 0 : Convert.ToInt32(r);
            }
        }

        private static decimal ScalarDec(SQLiteConnection conn, string sql, params (string, object)[] ps)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                foreach (var (k, v) in ps) cmd.Parameters.AddWithValue(k, v);
                var r = cmd.ExecuteScalar();
                return (r == null || r == DBNull.Value) ? 0m : Convert.ToDecimal(r);
            }
        }
    }
}
