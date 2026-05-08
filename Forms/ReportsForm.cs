using System;
using System.Data;
using System.Windows.Forms;
using GymSystem.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                DataTable dt = DatabaseHelper.GetPaymentsReport();
                dgvReport.DataSource = dt;

                int totalCount = dt.Rows.Count;
                decimal totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["Amount"]);
                }

                lblTotalPayments.Text = $"Total Payments: {totalCount}";
                lblTotalAmount.Text = $"Total Amount: ${totalAmount:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
