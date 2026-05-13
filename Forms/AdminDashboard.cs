using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GYM_Desktop_app.Models;
using GYM_Desktop_app.Database;

namespace GYM_Desktop_app.Forms
{
    public partial class AdminDashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        private bool _dragging;
        private Point _dragStart;
        private User _currentUser;

        public AdminDashboard(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {user.Username}!";
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ApplyGridStyle(dgvRecentMembers);
            LoadStats();
            LoadRecentMembers();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void LoadStats()
        {
            try
            {
                var members    = DatabaseHelper.GetAllMembers();
                var now        = DateTime.Now;
                var weekAgo    = now.AddDays(-7);
                var monthStart = new DateTime(now.Year, now.Month, 1);

                lblCardMembersVal.Text  = members.Count.ToString();
                lblCardActiveVal.Text   = members.Count(m => m.MembershipExpiry >= now).ToString();
                lblCardNewVal.Text      = members.Count(m => m.JoinDate >= weekAgo).ToString();

                // Revenue this month from payments report
                try
                {
                    var dt      = DatabaseHelper.GetPaymentsReport();
                    decimal rev = 0;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (Convert.ToDateTime(row["Date"]) >= monthStart)
                            rev += Convert.ToDecimal(row["Amount"]);
                    }
                    lblCardRevenueVal.Text = "$" + rev.ToString("N0");
                }
                catch
                {
                    lblCardRevenueVal.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message);
            }
        }

        private void LoadRecentMembers()
        {
            try
            {
                var members = DatabaseHelper.GetAllMembers()
                    .OrderByDescending(m => m.JoinDate)
                    .Take(20)
                    .ToList();
                dgvRecentMembers.DataSource = null;
                dgvRecentMembers.DataSource = members;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recent members: " + ex.Message);
            }
        }

        private void ApplyGridStyle(DataGridView dgv)
        {
            dgv.BackgroundColor                        = Color.White;
            dgv.BorderStyle                            = BorderStyle.None;
            dgv.GridColor                              = Color.FromArgb(230, 230, 230);
            dgv.RowHeadersVisible                      = false;
            dgv.AllowUserToAddRows                     = false;
            dgv.SelectionMode                          = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect                            = false;
            dgv.ReadOnly                               = true;
            dgv.EnableHeadersVisualStyles              = false;
            dgv.RowTemplate.Height                     = 40;
            dgv.DefaultCellStyle.Font                  = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.SelectionBackColor    = Color.FromArgb(0, 105, 110);
            dgv.DefaultCellStyle.SelectionForeColor    = Color.White;
            dgv.DefaultCellStyle.Padding               = new Padding(5, 0, 5, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgv.ColumnHeadersHeight                    = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(0, 105, 110);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding     = new Padding(5, 0, 5, 0);
        }

        private void btnManageMembers_Click(object sender, EventArgs e)
            => new ManageMembers().ShowDialog();

        private void btnManagePlans_Click(object sender, EventArgs e)
            => new ManagePlans().ShowDialog();

        private void btnManageTrainers_Click(object sender, EventArgs e)
            => new ManageTrainers().ShowDialog();

        private void btnPayments_Click(object sender, EventArgs e)
            => new PaymentForm().ShowDialog();

        private void btnReports_Click(object sender, EventArgs e)
            => new ReportsForm().ShowDialog();

        private void btnChangePassword_Click(object sender, EventArgs e)
            => new ChangePasswordForm(_currentUser).ShowDialog();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }
    }
}
