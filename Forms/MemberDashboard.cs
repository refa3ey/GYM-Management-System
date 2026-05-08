using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class MemberDashboard : Form
    {
        private User _currentUser;

        public MemberDashboard(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {user.Username}!";
            LoadMemberInfo();
        }

        private void LoadMemberInfo()
        {
            lblPlan.Text = "Plan: Active";
            lblExpiry.Text = "Expiry: Check with admin";
            lblStatus.Text = "Status: Active";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your workout schedule:\n\n" +
                "Monday: Cardio (30 min)\n" +
                "Wednesday: Strength Training\n" +
                "Friday: Yoga & Stretching",
                "Workout Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
