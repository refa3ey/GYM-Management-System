using GYM_Desktop_app.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GymSystem.Database
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["GymDBConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
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
                        string insert = "INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'admin123', 'Admin')";
                        using (var insertCmd = new SqlCommand(insert, conn))
                        {
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

        // ===== USER METHODS =====
        public static User ValidateUser(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Username=@u AND Password=@p";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                    }
                }
            }
            return null;
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
    }
}