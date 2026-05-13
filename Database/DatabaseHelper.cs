using GYM_Desktop_app.Helpers;
using GYM_Desktop_app.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GYM_Desktop_app.Database
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["GymDBConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // ===== PASSWORD HASHING =====
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return false;

            // Only attempt BCrypt verify if it looks like a BCrypt hash
            if (!hash.StartsWith("$2"))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }

        // ===== SEED =====
        public static void SeedAdmin()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string check = "SELECT COUNT(*) FROM Users WHERE Role='Admin'";
                using (var cmd = new SqlCommand(check, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insert = "INSERT INTO Users (Username, Password, Role) VALUES ('admin', @pwd, 'Admin')";
                        using (var insertCmd = new SqlCommand(insert, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@pwd", HashPassword("admin123"));
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void SeedPlans()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string check = "SELECT COUNT(*) FROM MembershipPlans";
                using (var cmd = new SqlCommand(check, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insert = @"INSERT INTO MembershipPlans (PlanName, DurationMonths, Price) VALUES
                            ('Monthly Plan', 1, 30.00),
                            ('Quarterly Plan', 3, 80.00),
                            ('Semi-Annual Plan', 6, 150.00),
                            ('Annual Plan', 12, 250.00)";
                        using (var insertCmd = new SqlCommand(insert, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void SeedInitialData()
        {
            SeedAdmin();
            SeedPlans();
        }

        // ===== USER METHODS =====
        public static User ValidateUser(string username, string password)
        {
            int userId = 0;
            string storedPassword = null;
            string role = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Username=@u";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["UserID"]);
                            storedPassword = reader["Password"].ToString();
                            role = reader["Role"].ToString();
                        }
                    }
                }
            }

            if (storedPassword == null) return null;

            // BCrypt hash — verified
            if (VerifyPassword(password, storedPassword))
                return new User { UserID = userId, Username = username, Role = role };

            // Legacy plain-text password — auto-upgrade to BCrypt on successful login
            if (storedPassword == password)
            {
                UpdateUserPassword(userId, HashPassword(password));
                return new User { UserID = userId, Username = username, Role = role };
            }

            return null;
        }

        public static void UpdateUserPassword(int userId, string newHashedPassword)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Users SET Password=@p WHERE UserID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.Parameters.AddWithValue("@p", newHashedPassword);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===== MEMBER METHODS =====
        public static List<Member> GetAllMembers()
        {
            var list = new List<Member>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Members", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Member
                        {
                            MemberID = Convert.ToInt32(reader["MemberID"]),
                            Name = reader["Name"].ToString(),
                            Phone = reader["Phone"]?.ToString(),
                            Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                            Address = reader["Address"]?.ToString(),
                            JoinDate = reader["JoinDate"] != DBNull.Value ? Convert.ToDateTime(reader["JoinDate"]) : DateTime.Now,
                            PlanID = reader["PlanID"] != DBNull.Value ? Convert.ToInt32(reader["PlanID"]) : 0,
                            MembershipExpiry = reader["MembershipExpiry"] != DBNull.Value ? Convert.ToDateTime(reader["MembershipExpiry"]) : DateTime.Now
                        });
                    }
                }
            }
            return list;
        }

        public static void AddMember(Member m, string username, string password)
        {
            password = HashPassword(password);
            using (var conn = GetConnection())
            {
                conn.Open();
                int userID;
                string addUser = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, 'Member'); SELECT SCOPE_IDENTITY();";
                using (var cmd = new SqlCommand(addUser, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    userID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string addMember = @"INSERT INTO Members (UserID, Name, Phone, Age, Address, JoinDate, PlanID, MembershipExpiry)
                                     VALUES (@uid, @name, @phone, @age, @addr, @join, @plan, @expiry)";
                using (var cmd = new SqlCommand(addMember, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userID);
                    cmd.Parameters.AddWithValue("@name", m.Name);
                    cmd.Parameters.AddWithValue("@phone", m.Phone ?? "");
                    cmd.Parameters.AddWithValue("@age", m.Age);
                    cmd.Parameters.AddWithValue("@addr", m.Address ?? "");
                    cmd.Parameters.AddWithValue("@join", m.JoinDate);
                    cmd.Parameters.AddWithValue("@plan", m.PlanID);
                    cmd.Parameters.AddWithValue("@expiry", m.MembershipExpiry);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateMember(Member m)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Members SET Name=@name, Phone=@phone, Age=@age,
                              Address=@addr, PlanID=@plan, MembershipExpiry=@expiry WHERE MemberID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", m.MemberID);
                    cmd.Parameters.AddWithValue("@name", m.Name);
                    cmd.Parameters.AddWithValue("@phone", m.Phone ?? "");
                    cmd.Parameters.AddWithValue("@age", m.Age);
                    cmd.Parameters.AddWithValue("@addr", m.Address ?? "");
                    cmd.Parameters.AddWithValue("@plan", m.PlanID);
                    cmd.Parameters.AddWithValue("@expiry", m.MembershipExpiry);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMember(int memberID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Members WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===== PLAN METHODS =====
        public static List<MembershipPlan> GetAllPlans()
        {
            var list = new List<MembershipPlan>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM MembershipPlans", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new MembershipPlan
                        {
                            PlanID = Convert.ToInt32(reader["PlanID"]),
                            PlanName = reader["PlanName"].ToString(),
                            DurationMonths = Convert.ToInt32(reader["DurationMonths"]),
                            Price = Convert.ToDecimal(reader["Price"])
                        });
                }
            }
            return list;
        }

        public static void AddPlan(MembershipPlan p)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("INSERT INTO MembershipPlans (PlanName, DurationMonths, Price) VALUES (@n, @d, @p)", conn))
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
                string sql = "UPDATE MembershipPlans SET PlanName=@n, DurationMonths=@d, Price=@p WHERE PlanID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.PlanID);
                    cmd.Parameters.AddWithValue("@n", p.PlanName);
                    cmd.Parameters.AddWithValue("@d", p.DurationMonths);
                    cmd.Parameters.AddWithValue("@p", p.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletePlan(int planID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM MembershipPlans WHERE PlanID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", planID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===== TRAINER METHODS =====
        public static List<Trainer> GetAllTrainers()
        {
            var list = new List<Trainer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Trainers", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new Trainer
                        {
                            TrainerID = Convert.ToInt32(reader["TrainerID"]),
                            Name = reader["Name"].ToString(),
                            Specialty = reader["Specialty"]?.ToString(),
                            Phone = reader["Phone"]?.ToString()
                        });
                }
            }
            return list;
        }

        public static void AddTrainer(Trainer t)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("INSERT INTO Trainers (Name, Specialty, Phone) VALUES (@n, @s, @p)", conn))
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
                using (var cmd = new SqlCommand("DELETE FROM Trainers WHERE TrainerID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", trainerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===== PAYMENT METHODS =====
        public static void AddPayment(Payment p)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("INSERT INTO Payments (MemberID, Amount, Date, Method) VALUES (@m, @a, @d, @meth)", conn))
                {
                    cmd.Parameters.AddWithValue("@m", p.MemberID);
                    cmd.Parameters.AddWithValue("@a", p.Amount);
                    cmd.Parameters.AddWithValue("@d", p.Date);
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
                string sql = @"SELECT p.PaymentID, m.Name AS MemberName, p.Amount, p.Date, p.Method
                               FROM Payments p JOIN Members m ON p.MemberID = m.MemberID";
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // ===== ATTENDANCE METHODS =====
        public static void EnsureAttendanceTable()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Attendance')
                    CREATE TABLE Attendance (
                        AttendanceID  INT IDENTITY PRIMARY KEY,
                        MemberID      INT NOT NULL,
                        CheckInTime   DATETIME NOT NULL,
                        CheckOutTime  DATETIME NULL,
                        Notes         NVARCHAR(500) NULL,
                        FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
                    )";
                using (var cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        public static bool IsMembershipValid(int memberID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT MembershipExpiry FROM Members WHERE MemberID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return false;
                    return Convert.ToDateTime(result) > DateTime.Now;
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
                using (var cmd = new SqlCommand("SELECT * FROM Members WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return ReadMember(reader);
                    }
                }
            }
            return null;
        }

        public static List<Member> FindMembers(string search)
        {
            var list = new List<Member>();
            if (string.IsNullOrWhiteSpace(search)) return list;

            // QR code / numeric ID lookup
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
                string sql = "SELECT * FROM Members WHERE Name LIKE @s OR Phone LIKE @s";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(ReadMember(reader));
                }
            }
            return list;
        }

        public static string GetPlanNameByID(int planID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT PlanName FROM MembershipPlans WHERE PlanID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", planID);
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "Member";
                }
            }
        }

        public static int GetTodayCheckInCount()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Attendance WHERE CAST(CheckInTime AS DATE) = CAST(GETDATE() AS DATE)";
                using (var cmd = new SqlCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static bool VerifyUserPassword(string username, string password)
            => ValidateUser(username, password) != null;

        public static Member GetMemberByUserID(int userID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Members WHERE UserID=@uid", conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return ReadMember(reader);
                    }
                }
            }
            return null;
        }

        private static Member ReadMember(SqlDataReader reader)
        {
            return new Member
            {
                MemberID         = Convert.ToInt32(reader["MemberID"]),
                Name             = reader["Name"].ToString(),
                Phone            = reader["Phone"]?.ToString(),
                Age              = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                Address          = reader["Address"]?.ToString(),
                JoinDate         = reader["JoinDate"] != DBNull.Value ? Convert.ToDateTime(reader["JoinDate"]) : DateTime.Now,
                PlanID           = reader["PlanID"] != DBNull.Value ? Convert.ToInt32(reader["PlanID"]) : 0,
                MembershipExpiry = reader["MembershipExpiry"] != DBNull.Value ? Convert.ToDateTime(reader["MembershipExpiry"]) : DateTime.Now
            };
        }

        public static int CheckInMember(int memberID, string notes = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Attendance (MemberID, CheckInTime, Notes)
                               VALUES (@mid, @time, @notes);
                               SELECT SCOPE_IDENTITY();";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mid", memberID);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
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
                string sql = "UPDATE Attendance SET CheckOutTime=@time WHERE AttendanceID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
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
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mid", memberID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return ReadAttendance(reader);
                    }
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
                               WHERE CAST(a.CheckInTime AS DATE) = CAST(GETDATE() AS DATE)
                               ORDER BY a.CheckInTime DESC";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(ReadAttendance(reader));
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
                if (memberID.HasValue)
                    sql += " AND a.MemberID=@mid";
                sql += " ORDER BY a.CheckInTime DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@from", from.Date);
                    cmd.Parameters.AddWithValue("@to", to.Date.AddDays(1));
                    if (memberID.HasValue)
                        cmd.Parameters.AddWithValue("@mid", memberID.Value);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(ReadAttendance(reader));
                }
            }
            return list;
        }

        public static (int today, int week, int month) GetAttendanceStats()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT
                        SUM(CASE WHEN CAST(CheckInTime AS DATE) = CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END) AS Today,
                        SUM(CASE WHEN CheckInTime >= DATEADD(day,-7,GETDATE())  THEN 1 ELSE 0 END) AS Week,
                        SUM(CASE WHEN CheckInTime >= DATEADD(day,-30,GETDATE()) THEN 1 ELSE 0 END) AS Month
                    FROM Attendance";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return (
                            reader["Today"] != DBNull.Value ? Convert.ToInt32(reader["Today"]) : 0,
                            reader["Week"]  != DBNull.Value ? Convert.ToInt32(reader["Week"])  : 0,
                            reader["Month"] != DBNull.Value ? Convert.ToInt32(reader["Month"]) : 0
                        );
                }
            }
            return (0, 0, 0);
        }

        private static Attendance ReadAttendance(SqlDataReader reader)
        {
            return new Attendance
            {
                AttendanceID = Convert.ToInt32(reader["AttendanceID"]),
                MemberID     = Convert.ToInt32(reader["MemberID"]),
                MemberName   = reader["Name"].ToString(),
                CheckInTime  = Convert.ToDateTime(reader["CheckInTime"]),
                CheckOutTime = reader["CheckOutTime"] != DBNull.Value
                                   ? (DateTime?)Convert.ToDateTime(reader["CheckOutTime"])
                                   : null,
                Notes        = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
            };
        }
    }
}