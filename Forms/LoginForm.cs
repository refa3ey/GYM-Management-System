
using GYM_Desktop_app.Models;
using GymSystem.Database;
using System;
using System.Windows.Forms;

namespace GYM_Desktop_app.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = DatabaseHelper.ValidateUser(username, password);

                if (user != null)
                {
                    this.Hide();
                    if (user.Role == "Admin")
                    {
                        AdminDashboard adminForm = new AdminDashboard(user);
                        adminForm.FormClosed += (s, args) => this.Close();
                        adminForm.Show();
                    }
                    else
                    {
                        MemberDashboard memberForm = new MemberDashboard(user);
                        memberForm.FormClosed += (s, args) => this.Close();
                        memberForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}