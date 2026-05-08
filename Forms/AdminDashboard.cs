using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class AdminDashboard : Form
    {
        private User _currentUser;

        public AdminDashboard(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {user.Username}!";
        }

        private void btnManageMembers_Click(object sender, EventArgs e)
        {
            new ManageMembers().ShowDialog();
        }

        private void btnManagePlans_Click(object sender, EventArgs e)
        {
            new ManagePlans().ShowDialog();
        }

        private void btnManageTrainers_Click(object sender, EventArgs e)
        {
            new ManageTrainers().ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            new PaymentForm().ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new ReportsForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }
    }
}
