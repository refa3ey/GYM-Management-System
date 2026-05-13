using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using GYM_Desktop_app.Database;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class CheckInStationForm : Form
    {
        private User _adminUser;
        private TimeSpan _checkoutDuration;

        private enum ResultType { CheckIn, CheckOut, Expired, NotFound, Error }

        public CheckInStationForm(User adminUser)
        {
            _adminUser = adminUser;
            InitializeComponent();
        }

        private void CheckInStationForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ResizeModePanel();
            timerClock.Start();
            timerRefocus.Start();
            UpdateTodayCount();
            ShowReadyMode();
        }

        private void CheckInStationForm_Resize(object sender, EventArgs e)
        {
            ResizeModePanel();
        }

        // ===== LAYOUT =====
        private void ResizeModePanel()
        {
            int top = pnlTopBar.Bottom;
            int w   = this.ClientSize.Width;
            int h   = this.ClientSize.Height - top;

            pnlModeReady.SetBounds(0, top, w, h);
            pnlModeResult.SetBounds(0, top, w, h);

            // Anchor top bar elements
            lblStationTitle.Left  = (w - lblStationTitle.Width) / 2;
            lblDateTime.Left      = w - lblDateTime.Width - 170;
            btnExitStation.Left   = w - btnExitStation.Width - 20;

            PositionReadyControls(w, h);
            PositionResultControls(w, h);
        }

        private void PositionReadyControls(int w, int h)
        {
            int cy    = h / 2;
            int scanW = Math.Min(800, w - 100);

            lblPrompt.SetBounds(30, cy - 185, w - 60, 60);
            lblSubtitle.SetBounds(30, cy - 115, w - 60, 38);

            txtScan.Width = scanW;
            txtScan.Left  = (w - scanW) / 2;
            txtScan.Top   = cy - 50;

            lblScannerHint.SetBounds(30, h - 72, w - 60, 30);
            lblTodayCount.SetBounds(w - 340, h - 48, 320, 30);
        }

        private void PositionResultControls(int w, int h)
        {
            int cy = h / 2;
            lblResultIcon.SetBounds((w - 400) / 2, cy - 280, 400, 240);
            lblResultName.SetBounds(40, cy - 30, w - 80, 110);
            lblResultDetails.SetBounds(40, cy + 88, w - 80, 44);
            lblResultTime.SetBounds(40, cy + 140, w - 80, 40);
            lblResultMessage.SetBounds(40, cy + 190, w - 80, 52);
        }

        // ===== CLOCK =====
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("ddd, MMM dd yyyy  HH:mm:ss");
        }

        // ===== REFOCUS =====
        private void timerRefocus_Tick(object sender, EventArgs e)
        {
            if (pnlModeReady.Visible && !txtScan.ContainsFocus)
                txtScan.Focus();
        }

        // ===== REVERT TIMER =====
        private void timerRevert_Tick(object sender, EventArgs e)
        {
            timerRevert.Stop();
            ShowReadyMode();
        }

        // ===== SCAN INPUT =====
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessScan(txtScan.Text.Trim());
            }
        }

        private void ProcessScan(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            txtScan.Clear();

            try
            {
                var matches = DatabaseHelper.FindMembers(input);
                if (matches.Count == 0)
                {
                    ShowResultMode(ResultType.NotFound, null);
                    SystemSounds.Hand.Play();
                    return;
                }

                var member = matches[0];

                if (!DatabaseHelper.IsMembershipValid(member.MemberID))
                {
                    ShowResultMode(ResultType.Expired, member);
                    SystemSounds.Hand.Play();
                    return;
                }

                var open = DatabaseHelper.GetOpenCheckIn(member.MemberID);
                if (open != null)
                {
                    _checkoutDuration = DateTime.Now - open.CheckInTime;
                    DatabaseHelper.CheckOutMember(open.AttendanceID);
                    ShowResultMode(ResultType.CheckOut, member);
                    SystemSounds.Beep.Play();
                }
                else
                {
                    DatabaseHelper.CheckInMember(member.MemberID);
                    ShowResultMode(ResultType.CheckIn, member);
                    SystemSounds.Beep.Play();
                }

                UpdateTodayCount();
            }
            catch (Exception ex)
            {
                ShowResultMode(ResultType.Error, null, ex.Message);
                SystemSounds.Hand.Play();
            }
        }

        // ===== RESULT MODE =====
        private void ShowResultMode(ResultType type, Member member, string errorMsg = null)
        {
            timerRefocus.Stop();

            string planName = "";
            if (member != null)
            {
                try { planName = DatabaseHelper.GetPlanNameByID(member.PlanID); }
                catch { planName = "Member"; }
            }

            switch (type)
            {
                case ResultType.CheckIn:
                    pnlModeResult.BackColor    = Color.FromArgb(220, 250, 220);
                    lblResultIcon.Text         = "✓";
                    lblResultIcon.ForeColor    = Color.FromArgb(40, 167, 69);
                    lblResultName.Text         = $"Welcome, {member.Name}!";
                    lblResultName.ForeColor    = Color.FromArgb(20, 100, 35);
                    lblResultDetails.Text      = $"{planName}  •  Expires {member.MembershipExpiry:MMM dd, yyyy}";
                    lblResultDetails.ForeColor = Color.FromArgb(40, 80, 40);
                    lblResultTime.Text         = $"Checked in at {DateTime.Now:HH:mm}";
                    lblResultTime.ForeColor    = Color.FromArgb(60, 100, 60);
                    lblResultMessage.Text      = "Have a great workout!";
                    lblResultMessage.ForeColor = Color.FromArgb(40, 167, 69);
                    StartRevertTimer(3000);
                    break;

                case ResultType.CheckOut:
                    int mins = (int)_checkoutDuration.TotalMinutes;
                    pnlModeResult.BackColor    = Color.FromArgb(220, 230, 250);
                    lblResultIcon.Text         = "OK";
                    lblResultIcon.ForeColor    = Color.FromArgb(30, 80, 160);
                    lblResultName.Text         = $"Goodbye, {member.Name}!";
                    lblResultName.ForeColor    = Color.FromArgb(20, 60, 140);
                    lblResultDetails.Text      = $"Workout duration: {mins / 60}h {mins % 60}m";
                    lblResultDetails.ForeColor = Color.FromArgb(30, 70, 130);
                    lblResultTime.Text         = $"Checked out at {DateTime.Now:HH:mm}";
                    lblResultTime.ForeColor    = Color.FromArgb(40, 80, 150);
                    lblResultMessage.Text      = "See you next time!";
                    lblResultMessage.ForeColor = Color.FromArgb(30, 80, 160);
                    StartRevertTimer(3000);
                    break;

                case ResultType.Expired:
                    pnlModeResult.BackColor    = Color.FromArgb(255, 220, 220);
                    lblResultIcon.Text         = "X";
                    lblResultIcon.ForeColor    = Color.FromArgb(220, 53, 69);
                    lblResultName.Text         = member.Name;
                    lblResultName.ForeColor    = Color.FromArgb(150, 20, 30);
                    lblResultDetails.Text      = $"Membership expired on {member.MembershipExpiry:MMM dd, yyyy}";
                    lblResultDetails.ForeColor = Color.FromArgb(160, 30, 40);
                    lblResultTime.Text         = "Please renew at the front desk";
                    lblResultTime.ForeColor    = Color.FromArgb(140, 20, 30);
                    lblResultMessage.Text      = "";
                    StartRevertTimer(4000);
                    break;

                case ResultType.NotFound:
                    pnlModeResult.BackColor    = Color.FromArgb(255, 220, 220);
                    lblResultIcon.Text         = "X";
                    lblResultIcon.ForeColor    = Color.FromArgb(220, 53, 69);
                    lblResultName.Text         = "Member Not Found";
                    lblResultName.ForeColor    = Color.FromArgb(150, 20, 30);
                    lblResultDetails.Text      = "Please check your code or see the front desk";
                    lblResultDetails.ForeColor = Color.FromArgb(160, 30, 40);
                    lblResultTime.Text         = "";
                    lblResultMessage.Text      = "";
                    StartRevertTimer(4000);
                    break;

                case ResultType.Error:
                    pnlModeResult.BackColor    = Color.FromArgb(255, 220, 220);
                    lblResultIcon.Text         = "!";
                    lblResultIcon.ForeColor    = Color.FromArgb(220, 53, 69);
                    lblResultName.Text         = "System Error";
                    lblResultName.ForeColor    = Color.FromArgb(150, 20, 30);
                    lblResultDetails.Text      = errorMsg ?? "An unexpected error occurred";
                    lblResultDetails.ForeColor = Color.FromArgb(160, 30, 40);
                    lblResultTime.Text         = "";
                    lblResultMessage.Text      = "";
                    StartRevertTimer(4000);
                    break;
            }

            pnlModeReady.Visible   = false;
            pnlModeResult.Visible  = true;
            PositionResultControls(pnlModeResult.Width, pnlModeResult.Height);
        }

        private void ShowReadyMode()
        {
            pnlModeResult.Visible = false;
            pnlModeReady.Visible  = true;
            PositionReadyControls(pnlModeReady.Width, pnlModeReady.Height);
            timerRefocus.Start();
            txtScan.Focus();
        }

        private void StartRevertTimer(int ms)
        {
            timerRevert.Stop();
            timerRevert.Interval = ms;
            timerRevert.Start();
        }

        private void UpdateTodayCount()
        {
            try
            {
                int count = DatabaseHelper.GetTodayCheckInCount();
                lblTodayCount.Text = $"Check-ins today: {count}";
            }
            catch { }
        }

        // ===== EXIT STATION =====
        private void btnExitStation_Click(object sender, EventArgs e)
        {
            timerRefocus.Stop();
            string pwd = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter admin password to exit station mode:", "Exit Station Mode", "");

            if (string.IsNullOrWhiteSpace(pwd))
            {
                timerRefocus.Start();
                return;
            }

            if (DatabaseHelper.VerifyUserPassword(_adminUser.Username, pwd))
            {
                this.Close();
            }
            else
            {
                string saved = lblDateTime.Text;
                lblDateTime.Text = "  Incorrect password. Try again.";
                var t = new Timer { Interval = 2000 };
                t.Tick += (s, args) =>
                {
                    t.Stop();
                    t.Dispose();
                    lblDateTime.Text = saved;
                };
                t.Start();
                timerRefocus.Start();
            }
        }
    }
}
