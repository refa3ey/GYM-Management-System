using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GymSystem.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            LoadPlans();
        }

        private void LoadPlans()
        {
            try
            {
                var plans = DatabaseHelper.GetAllPlans();
                cmbPlan.DataSource = plans;
                cmbPlan.DisplayMember = "PlanName";
                cmbPlan.ValueMember = "PlanID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plans: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPlan.SelectedValue == null)
            {
                MessageBox.Show("Please select a membership plan.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int planID = Convert.ToInt32(cmbPlan.SelectedValue);
                var selectedPlan = (MembershipPlan)cmbPlan.SelectedItem;

                var member = new Member
                {
                    Name = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Age = (int)numAge.Value,
                    Address = txtAddress.Text.Trim(),
                    JoinDate = DateTime.Now,
                    PlanID = planID,
                    MembershipExpiry = DateTime.Now.AddMonths(selectedPlan.DurationMonths)
                };

                DatabaseHelper.AddMember(member, txtUsername.Text.Trim(), txtPassword.Text.Trim());

                MessageBox.Show("Registration successful! You can now login.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char pwdChar = chkShowPassword.Checked ? '\0' : '*';
            txtPassword.PasswordChar = pwdChar;
            txtConfirmPassword.PasswordChar = pwdChar;
        }
    }
}
