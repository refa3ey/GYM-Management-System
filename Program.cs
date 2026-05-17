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
            // Resolve the writable data directory and copy the DB there on first run.
            // Program Files is read-only for LocalDB writes, so we use %LOCALAPPDATA%.
            string dataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GYM PRO");

            try
            {
                Directory.CreateDirectory(dataDir);

                string destMdf = Path.Combine(dataDir, "GymDB.mdf");
                if (!File.Exists(destMdf))
                {
                    string installDir = AppDomain.CurrentDomain.BaseDirectory;
                    string srcMdf = Path.Combine(installDir, "GymDB.mdf");
                    string srcLdf = Path.Combine(installDir, "GymDB_log.ldf");

                    File.Copy(srcMdf, destMdf);

                    if (File.Exists(srcLdf))
                        File.Copy(srcLdf, Path.Combine(dataDir, "GymDB_log.ldf"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not initialise the database folder:\n\n" + ex.Message +
                    "\n\nPath: " + dataDir,
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Point |DataDirectory| to the writable copy
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DatabaseHelper.SeedAdmin();
                DatabaseHelper.SeedPlans();
                DatabaseHelper.EnsureAttendanceTable();
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
