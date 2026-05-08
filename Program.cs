using System;
using System.Windows.Forms;
using GYM_Desktop_app.Forms;
using GymSystem.Database;

namespace GYM_Desktop_app
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
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