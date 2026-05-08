using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GymSystem.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
            LoadMembers();
            if (cmbMethod.Items.Count > 0)
                cmbMethod.SelectedIndex = 0;
        }

        private void LoadMembers()
        {
            try
            {
                var members = DatabaseHelper.GetAllMembers();
                cmbMember.DataSource = members;
                cmbMember.DisplayMember = "Name";
                cmbMember.ValueMember = "MemberID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.");
                return;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.");
                return;
            }

            if (cmbMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            try
            {
                var payment = new Payment
                {
                    MemberID = Convert.ToInt32(cmbMember.SelectedValue),
                    Amount = numAmount.Value,
                    Date = dtpDate.Value,
                    Method = cmbMethod.SelectedItem.ToString()
                };

                DatabaseHelper.AddPayment(payment);
                MessageBox.Show("Payment recorded successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                numAmount.Value = 0;
                dtpDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
