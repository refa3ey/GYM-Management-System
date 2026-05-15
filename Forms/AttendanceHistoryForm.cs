using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GYM_Desktop_app.Database;
using GYM_Desktop_app.Helpers;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class AttendanceHistoryForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        private bool  _dragging;
        private Point _dragStart;
        private List<Attendance> _currentList = new List<Attendance>();

        public AttendanceHistoryForm()
        {
            InitializeComponent();
        }

        private void AttendanceHistoryForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));
            ApplyGridStyle(dgvHistory);
            LoadMembers();
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value   = DateTime.Today;
            ApplyFilter();
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

        private void LoadMembers()
        {
            try
            {
                var members = DatabaseHelper.GetAllMembers();
                cmbMember.Items.Clear();
                cmbMember.Items.Add(new MemberItem { MemberID = 0, Name = "All Members" });
                foreach (var m in members)
                    cmbMember.Items.Add(new MemberItem { MemberID = m.MemberID, Name = m.Name });
                cmbMember.SelectedIndex = 0;
            }
            catch { }
        }

        private void ApplyFilter()
        {
            try
            {
                int? memberID = null;
                if (cmbMember.SelectedItem is MemberItem mi && mi.MemberID > 0)
                    memberID = mi.MemberID;

                _currentList = DatabaseHelper.GetAttendanceByDateRange(dtpFrom.Value, dtpTo.Value, memberID);
                var list = _currentList;
                dgvHistory.DataSource = list;

                int completed = 0;
                long totalMins = 0;
                foreach (var a in list)
                {
                    if (a.CheckOutTime.HasValue)
                    {
                        completed++;
                        totalMins += (long)(a.CheckOutTime.Value - a.CheckInTime).TotalMinutes;
                    }
                }

                string avgDur = completed > 0
                    ? $"{totalMins / completed}m avg"
                    : "—";
                lblSummary.Text =
                    $"Total: {list.Count} visits  |  Completed: {completed}  |  Avg duration: {avgDur}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvHistory.Columns.Count == 0) return;

            foreach (string col in new[] { "AttendanceID", "MemberID", "Notes", "Status" })
                if (dgvHistory.Columns.Contains(col))
                    dgvHistory.Columns[col].Visible = false;

            var headers = new Dictionary<string, (string h, int w)>
            {
                { "MemberName",   ("Member",    200) },
                { "CheckInTime",  ("Check In",  170) },
                { "CheckOutTime", ("Check Out", 170) },
                { "Duration",     ("Duration",  120) },
            };
            foreach (var kv in headers)
            {
                if (!dgvHistory.Columns.Contains(kv.Key)) continue;
                dgvHistory.Columns[kv.Key].HeaderText = kv.Value.h;
                dgvHistory.Columns[kv.Key].Width      = kv.Value.w;
            }

            if (dgvHistory.Columns.Contains("CheckInTime"))
                dgvHistory.Columns["CheckInTime"].DefaultCellStyle.Format = "MMM dd, yyyy  HH:mm";
            if (dgvHistory.Columns.Contains("CheckOutTime"))
                dgvHistory.Columns["CheckOutTime"].DefaultCellStyle.Format = "MMM dd, yyyy  HH:mm";
        }

        private void dgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var list = dgvHistory.DataSource as List<Attendance>;
            if (list == null || e.RowIndex >= list.Count) return;
            var att     = list[e.RowIndex];
            var colName = dgvHistory.Columns[e.ColumnIndex].Name;

            if (colName == "Duration")
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

        private void btnApply_Click(object sender, EventArgs e) => ApplyFilter();

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_currentList == null || _currentList.Count == 0)
            {
                MessageBox.Show("No records to export. Apply a filter first.", "Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = ExportDialog.PromptForExcelPath(
                $"Attendance_{dtpFrom.Value:yyyyMMdd}_{dtpTo.Value:yyyyMMdd}.xlsx");
            if (path == null) return;
            try
            {
                ExportHelper.ExportAttendanceToExcel(path, _currentList, dtpFrom.Value, dtpTo.Value);
                if (MessageBox.Show("Excel file saved.\n\nOpen it now?", "Export Complete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ExportHelper.OpenFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class MemberItem
        {
            public int    MemberID { get; set; }
            public string Name     { get; set; }
            public override string ToString() => Name;
        }
    }
}
