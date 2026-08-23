using System;
using System.IO;
using System.Windows.Forms;
using GYM_Desktop_app.Forms;
using GYM_Desktop_app.Database;

namespace GYM_Desktop_app
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Embedded SQLite database in a writable per-user folder.
            // No SQL Server / LocalDB required - the file is created on first run.
            string dataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GYM PRO");

            try
            {
                Directory.CreateDirectory(dataDir);
                DatabaseHelper.SetDatabasePath(Path.Combine(dataDir, "gym.db"));
                DatabaseHelper.EnsureSchema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not initialise the database:\n\n" + ex.Message +
                    "\n\nPath: " + dataDir,
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DatabaseHelper.SeedAdmin();
                DatabaseHelper.SeedPlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB init error: " + ex.Message, "Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Run(new LoginForm());
        }
    }
}
