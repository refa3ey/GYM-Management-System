using System;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GymSystem.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class ManageTrainers : Form
    {
        private int selectedTrainerID = 0;

        public ManageTrainers()
        {
            InitializeComponent();
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            try
            {
                dgvTrainers.DataSource = null;
                dgvTrainers.DataSource = DatabaseHelper.GetAllTrainers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Trainer name is required.");
                return;
            }

            try
            {
                var trainer = new Trainer
                {
                    Name = txtName.Text.Trim(),
                    Specialty = txtSpecialty.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };
                DatabaseHelper.AddTrainer(trainer);
                MessageBox.Show("Trainer added!");
                LoadTrainers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTrainerID == 0)
            {
                MessageBox.Show("Select a trainer first.");
                return;
            }

            var result = MessageBox.Show("Delete this trainer?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteTrainer(selectedTrainerID);
                    MessageBox.Show("Trainer deleted.");
                    LoadTrainers();
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

        private void dgvTrainers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTrainers.Rows[e.RowIndex];
                selectedTrainerID = Convert.ToInt32(row.Cells["TrainerID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpecialty.Text = row.Cells["Specialty"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            }
        }

        private void ClearFields()
        {
            selectedTrainerID = 0;
            txtName.Clear();
            txtSpecialty.Clear();
            txtPhone.Clear();
        }
    }
}
