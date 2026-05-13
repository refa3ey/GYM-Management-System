using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GYM_Desktop_app.Database;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class AttendanceForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        private bool   _dragging;
        private Point  _dragStart;
        private readonly System.Windows.Forms.Timer _feedbackTimer =
            new System.Windows.Forms.Timer { Interval = 4000 };

        public AttendanceForm()
        {
            InitializeComponent();
            _feedbackTimer.Tick += (s, e) => { _feedbackTimer.Stop(); pnlFeedback.Visible = false; };
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));
            ApplyGridStyle(dgvToday);
            LoadTodayAttendance();
            LoadStats();
        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e) { _dragging = true; _dragStart = e.Location; }
        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging) Location = new Point(Location.X + e.X - _dragStart.X, Location.Y + e.Y - _dragStart.Y);
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
            dgv.EnableHeadersVisualStyles                 = false;
            dgv.RowTemplate.Height                        = 40;
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

        private void LoadTodayAttendance()
        {
            try
            {
                dgvToday.DataSource = DatabaseHelper.GetTodayAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void LoadStats()
        {
            try
            {
                var (today, week, month) = DatabaseHelper.GetAttendanceStats();
                lblStatTodayVal.Text = today.ToString();
                lblStatWeekVal.Text  = week.ToString();
                lblStatMonthVal.Text = month.ToString();
            }
            catch { }
        }

        private void dgvToday_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvToday.Columns.Count == 0) return;

            foreach (string col in new[] { "AttendanceID", "MemberID", "Notes", "Status" })
                if (dgvToday.Columns.Contains(col))
                    dgvToday.Columns[col].Visible = false;

            var headers = new Dictionary<string, (string h, int w)>
            {
                { "MemberName",   ("Member",    200) },
                { "CheckInTime",  ("Check In",  155) },
                { "CheckOutTime", ("Check Out", 155) },
                { "Duration",     ("Duration",  115) },
            };
            foreach (var kv in headers)
            {
                if (!dgvToday.Columns.Contains(kv.Key)) continue;
                dgvToday.Columns[kv.Key].HeaderText = kv.Value.h;
                dgvToday.Columns[kv.Key].Width      = kv.Value.w;
            }

            if (dgvToday.Columns.Contains("CheckInTime"))
                dgvToday.Columns["CheckInTime"].DefaultCellStyle.Format = "HH:mm:ss";
            if (dgvToday.Columns.Contains("CheckOutTime"))
                dgvToday.Columns["CheckOutTime"].DefaultCellStyle.Format = "HH:mm:ss";

            // Add action column once
            if (!dgvToday.Columns.Contains("colAction"))
            {
                dgvToday.Columns.Add(new DataGridViewButtonColumn
                {
                    Name                        = "colAction",
                    HeaderText                  = "Action",
                    UseColumnTextForButtonValue = false,
                    Width                       = 110,
                    FlatStyle                   = FlatStyle.Flat,
                });
            }
            dgvToday.Columns["colAction"].DisplayIndex = dgvToday.Columns.Count - 1;
        }

        private void dgvToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var list = dgvToday.DataSource as List<Attendance>;
            if (list == null || e.RowIndex >= list.Count) return;
            var att     = list[e.RowIndex];
            var colName = dgvToday.Columns[e.ColumnIndex].Name;

            if (colName == "colAction")
            {
                e.Value               = att.CheckOutTime.HasValue ? "—" : "Check Out";
                e.FormattingApplied   = true;
            }
            else if (colName == "Duration")
            {
                if (att.Duration.HasValue)
                {
                    var d = att.Duration.Value;
                    e.Value = d.TotalHours >= 1
                        ? $"{(int)d.TotalHours}h {d.Minutes}m"
                        : $"{d.Minutes}m";
                }
                else
                {
                    e.Value = "In progress";
                }
                e.FormattingApplied = true;
            }
        }

        private void dgvToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!dgvToday.Columns.Contains("colAction")) return;
            if (dgvToday.Columns[e.ColumnIndex].Name != "colAction") return;

            var list = dgvToday.DataSource as List<Attendance>;
            if (list == null || e.RowIndex >= list.Count) return;
            var att = list[e.RowIndex];
            if (att.CheckOutTime.HasValue) return;

            try
            {
                DatabaseHelper.CheckOutMember(att.AttendanceID);
                LoadTodayAttendance();
                LoadStats();
                ShowFeedback($"{att.MemberName} checked out", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check-out error: " + ex.Message);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e) => PerformCheckIn(txtMemberInput.Text.Trim());

        private void txtMemberInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformCheckIn(txtMemberInput.Text.Trim());
                e.Handled = true;
            }
        }

        private void PerformCheckIn(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            try
            {
                var member = DatabaseHelper.FindMember(input);
                if (member == null)
                {
                    ShowFeedback("Member not found", false);
                    return;
                }

                if (!DatabaseHelper.IsMembershipValid(member.MemberID))
                {
                    ShowFeedback($"{member.Name}: Membership expired!", false);
                    return;
                }

                var open = DatabaseHelper.GetOpenCheckIn(member.MemberID);
                if (open != null)
                {
                    DatabaseHelper.CheckOutMember(open.AttendanceID);
                    ShowFeedback($"{member.Name} checked out at {DateTime.Now:HH:mm}", true);
                }
                else
                {
                    DatabaseHelper.CheckInMember(member.MemberID);
                    ShowFeedback($"{member.Name} checked in at {DateTime.Now:HH:mm}", true);
                }

                txtMemberInput.Text = "";
                LoadTodayAttendance();
                LoadStats();
            }
            catch (Exception ex)
            {
                ShowFeedback("Error: " + ex.Message, false);
            }
        }

        private void ShowFeedback(string msg, bool success)
        {
            lblFeedback.Text          = msg;
            pnlFeedback.BackColor     = success ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
            pnlFeedback.Visible       = true;
            _feedbackTimer.Stop();
            _feedbackTimer.Start();
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
            => new AttendanceHistoryForm().ShowDialog();
    }
}
