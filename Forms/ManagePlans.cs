using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GymSystem.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class ManagePlans : Form
    {
        private int selectedPlanID = 0;

        public ManagePlans()
        {
            InitializeComponent();
            LoadPlans();
        }

        private void LoadPlans()
        {
            try
            {
                dgvPlans.DataSource = null;
                dgvPlans.DataSource = DatabaseHelper.GetAllPlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlanName.Text))
            {
                MessageBox.Show("Please enter plan name.");
                return;
            }

            try
            {
                var plan = new MembershipPlan
                {
                    PlanName = txtPlanName.Text.Trim(),
                    DurationMonths = (int)numDuration.Value,
                    Price = numPrice.Value
                };
                DatabaseHelper.AddPlan(plan);
                MessageBox.Show("Plan added!");
                LoadPlans();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPlanID == 0)
            {
                MessageBox.Show("Please select a plan from the table first.", "No Plan Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPlanName.Text))
            {
                MessageBox.Show("Please enter a plan name.");
                return;
            }

            try
            {
                var plan = new MembershipPlan
                {
                    PlanID = selectedPlanID,
                    PlanName = txtPlanName.Text.Trim(),
                    DurationMonths = (int)numDuration.Value,
                    Price = numPrice.Value
                };
                DatabaseHelper.UpdatePlan(plan);
                MessageBox.Show("Plan updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlans();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPlanID == 0)
            {
                MessageBox.Show("Select a plan first.");
                return;
            }

            var result = MessageBox.Show("Delete this plan?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeletePlan(selectedPlanID);
                    MessageBox.Show("Plan deleted.");
                    LoadPlans();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPlans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPlans.Rows[e.RowIndex];
                selectedPlanID = Convert.ToInt32(row.Cells["PlanID"].Value);
                txtPlanName.Text = row.Cells["PlanName"].Value.ToString();
                numDuration.Value = Convert.ToInt32(row.Cells["DurationMonths"].Value);
                numPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
            }
        }

        private void ClearFields()
        {
            selectedPlanID = 0;
            txtPlanName.Clear();
            numDuration.Value = 1;
            numPrice.Value = 0;
        }
    }
}
