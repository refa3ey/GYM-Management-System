using System;
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
            // Make |DataDirectory| in connection strings resolve to the exe's folder
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

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