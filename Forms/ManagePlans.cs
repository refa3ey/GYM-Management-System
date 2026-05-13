using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GYM_Desktop_app.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class ManagePlans : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        private bool _dragging;
        private Point _dragStart;
        private int selectedPlanID = 0;

        public ManagePlans()
        {
            InitializeComponent();
            LoadPlans();
        }

        private void ManagePlans_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));
            ApplyGridStyle(dgvPlans);
        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragStart = e.Location;
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
                Location = new Point(Location.X + e.X - _dragStart.X, Location.Y + e.Y - _dragStart.Y);
        }

        private void DragPanel_MouseUp(object sender, MouseEventArgs e) => _dragging = false;

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void ApplyGridStyle(DataGridView dgv)
        {
            dgv.BackgroundColor                           = Color.White;
            dgv.BorderStyle                               = BorderStyle.None;
            dgv.GridColor                                 = Color.FromArgb(230, 230, 230);
            dgv.RowHeadersVisible                         = false;
            dgv.AllowUserToAddRows                        = false;
            dgv.SelectionMode                             = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect                               = false;
            dgv.ReadOnly                                  = true;
            dgv.EnableHeadersVisualStyles                 = false;
            dgv.RowTemplate.Height                        = 38;
            dgv.DefaultCellStyle.Font                     = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(0, 105, 110);
            dgv.DefaultCellStyle.SelectionForeColor       = Color.White;
            dgv.DefaultCellStyle.Padding                  = new Padding(5, 0, 5, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgv.ColumnHeadersHeight                       = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(0, 105, 110);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding     = new Padding(5, 0, 5, 0);
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
                    PlanName       = txtPlanName.Text.Trim(),
                    DurationMonths = (int)numDuration.Value,
                    Price          = numPrice.Value
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
                    PlanID         = selectedPlanID,
                    PlanName       = txtPlanName.Text.Trim(),
                    DurationMonths = (int)numDuration.Value,
                    Price          = numPrice.Value
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

        private void dgvPlans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row          = dgvPlans.Rows[e.RowIndex];
                selectedPlanID   = Convert.ToInt32(row.Cells["PlanID"].Value);
                txtPlanName.Text = row.Cells["PlanName"].Value.ToString();
                numDuration.Value= Convert.ToInt32(row.Cells["DurationMonths"].Value);
                numPrice.Value   = Convert.ToDecimal(row.Cells["Price"].Value);
            }
        }

        private void ClearFields()
        {
            selectedPlanID   = 0;
            txtPlanName.Clear();
            numDuration.Value = 1;
            numPrice.Value    = 0;
        }
    }
}
