using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GYM_Desktop_app.Database;
using GYM_Desktop_app.Helpers;
using GYM_Desktop_app.Models;

namespace GYM_Desktop_app.Forms
{
    public partial class MemberDashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);

        private bool _dragging;
        private Point _dragStart;
        private User _currentUser;
        private Member _member;

        public MemberDashboard(User user)
        {
            InitializeComponent();
            _currentUser    = user;
            lblWelcome.Text = $"Welcome, {user.Username}!";
            LoadMemberInfo();
        }

        private void MemberDashboard_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void LoadMemberInfo()
        {
            try
            {
                _member = DatabaseHelper.GetMemberByUserID(_currentUser.UserID);
                if (_member == null) return;

                var plans = DatabaseHelper.GetAllPlans();
                var plan  = plans.FirstOrDefault(p => p.PlanID == _member.PlanID);
                lblPlan.Text   = plan?.PlanName ?? "—";
                lblExpiry.Text = _member.MembershipExpiry.ToString("MMM dd, yyyy");

                bool active    = _member.MembershipExpiry > DateTime.Now;
                lblStatus.Text      = active ? "Active" : "Expired";
                lblStatus.ForeColor = active
                    ? Color.FromArgb(40, 167, 69)
                    : Color.FromArgb(220, 53, 69);

                var qr = QRHelper.GenerateMemberQR(_member.MemberID);
                picMyQR.Image      = qr;
                lblMemberCode.Text = $"Code: MBR-{_member.MemberID}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadMemberInfo: " + ex.Message);
            }
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            if (picMyQR.Image == null) return;
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title    = "Save QR Code";
                dlg.Filter   = "PNG Image|*.png";
                dlg.FileName = $"MBR-{_member?.MemberID}-QR.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picMyQR.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("QR code saved successfully!", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPrintCard_Click(object sender, EventArgs e)
        {
            if (_member == null)
            {
                MessageBox.Show("Member data not loaded yet. Please wait.");
                return;
            }
            new MemberCardPrintForm(_member).ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
            => new ChangePasswordForm(_currentUser).ShowDialog();

        private void btnSelfCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                var member = DatabaseHelper.GetMemberByUserID(_currentUser.UserID);
                if (member == null)
                {
                    MessageBox.Show("No member account is linked to your user.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DatabaseHelper.IsMembershipValid(member.MemberID))
                {
                    MessageBox.Show("Your membership has expired. Please renew with an administrator.",
                        "Membership Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var open = DatabaseHelper.GetOpenCheckIn(member.MemberID);
                if (open != null)
                {
                    DatabaseHelper.CheckOutMember(open.AttendanceID);
                    MessageBox.Show($"Checked out successfully at {DateTime.Now:HH:mm}.",
                        "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DatabaseHelper.CheckInMember(member.MemberID);
                    MessageBox.Show($"Checked in successfully at {DateTime.Now:HH:mm}. Welcome, {member.Name}!",
                        "Checked In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your workout schedule:\n\n" +
                "Monday: Cardio (30 min)\n" +
                "Wednesday: Strength Training\n" +
                "Friday: Yoga & Stretching",
                "Workout Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }
    }
}
