namespace GYM_Desktop_app.Forms
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTopBar       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle          = new System.Windows.Forms.Label();
            this.btnClose          = new Guna.UI2.WinForms.Guna2Button();
            this.panelCheckIn      = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCheckInTitle   = new System.Windows.Forms.Label();
            this.txtMemberInput    = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCheckIn        = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFeedback       = new System.Windows.Forms.Panel();
            this.lblFeedback       = new System.Windows.Forms.Label();
            this.lblTodayTitle     = new System.Windows.Forms.Label();
            this.dgvToday          = new System.Windows.Forms.DataGridView();
            this.panelStats        = new System.Windows.Forms.Panel();
            this.lblStatTodayName  = new System.Windows.Forms.Label();
            this.lblStatTodayVal   = new System.Windows.Forms.Label();
            this.lblStatWeekName   = new System.Windows.Forms.Label();
            this.lblStatWeekVal    = new System.Windows.Forms.Label();
            this.lblStatMonthName  = new System.Windows.Forms.Label();
            this.lblStatMonthVal   = new System.Windows.Forms.Label();
            this.btnViewHistory    = new Guna.UI2.WinForms.Guna2Button();
            this.panelTopBar.SuspendLayout();
            this.panelCheckIn.SuspendLayout();
            this.pnlFeedback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToday)).BeginInit();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTopBar
            //
            this.panelTopBar.Controls.Add(this.lblTitle);
            this.panelTopBar.Controls.Add(this.btnClose);
            this.panelTopBar.FillColor = System.Drawing.Color.White;
            this.panelTopBar.Location  = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name      = "panelTopBar";
            this.panelTopBar.Size      = new System.Drawing.Size(1000, 65);
            this.panelTopBar.TabIndex  = 0;
            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.panelTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            this.panelTopBar.MouseUp   += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseUp);
            //
            // lblTitle
            //
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTitle.Location  = new System.Drawing.Point(25, 17);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(400, 32);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "Attendance Tracking";
            //
            // btnClose
            //
            this.btnClose.BorderRadius = 20;
            this.btnClose.FillColor    = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.Font         = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor    = System.Drawing.Color.White;
            this.btnClose.Location     = new System.Drawing.Point(960, 18);
            this.btnClose.Name         = "btnClose";
            this.btnClose.Size         = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex     = 1;
            this.btnClose.Text         = "✕";
            this.btnClose.Click       += new System.EventHandler(this.btnClose_Click);
            //
            // panelCheckIn
            //
            this.panelCheckIn.Controls.Add(this.lblCheckInTitle);
            this.panelCheckIn.Controls.Add(this.txtMemberInput);
            this.panelCheckIn.Controls.Add(this.btnCheckIn);
            this.panelCheckIn.Controls.Add(this.pnlFeedback);
            this.panelCheckIn.BorderColor     = System.Drawing.Color.FromArgb(230, 230, 230);
            this.panelCheckIn.BorderRadius    = 12;
            this.panelCheckIn.BorderThickness = 1;
            this.panelCheckIn.FillColor       = System.Drawing.Color.White;
            this.panelCheckIn.Location        = new System.Drawing.Point(10, 75);
            this.panelCheckIn.Name            = "panelCheckIn";
            this.panelCheckIn.Size            = new System.Drawing.Size(980, 115);
            this.panelCheckIn.TabIndex        = 1;
            //
            // lblCheckInTitle
            //
            this.lblCheckInTitle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCheckInTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCheckInTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblCheckInTitle.Name      = "lblCheckInTitle";
            this.lblCheckInTitle.Size      = new System.Drawing.Size(200, 24);
            this.lblCheckInTitle.TabIndex  = 0;
            this.lblCheckInTitle.Text      = "Quick Check-In";
            //
            // txtMemberInput
            //
            this.txtMemberInput.BorderRadius                  = 8;
            this.txtMemberInput.DefaultText                   = "";
            this.txtMemberInput.FocusedState.BorderColor      = System.Drawing.Color.FromArgb(0, 105, 110);
            this.txtMemberInput.Font                          = new System.Drawing.Font("Segoe UI", 14F);
            this.txtMemberInput.ForeColor           = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtMemberInput.Location            = new System.Drawing.Point(18, 44);
            this.txtMemberInput.Name                = "txtMemberInput";
            this.txtMemberInput.PlaceholderText     = "Member ID or scan QR code (e.g. 12 or MBR-12)...";
            this.txtMemberInput.Size                = new System.Drawing.Size(580, 50);
            this.txtMemberInput.TabIndex            = 1;
            this.txtMemberInput.KeyDown            += new System.Windows.Forms.KeyEventHandler(this.txtMemberInput_KeyDown);
            //
            // btnCheckIn
            //
            this.btnCheckIn.BorderRadius         = 8;
            this.btnCheckIn.FillColor            = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCheckIn.Font                 = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor            = System.Drawing.Color.White;
            this.btnCheckIn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 130, 55);
            this.btnCheckIn.Location             = new System.Drawing.Point(608, 44);
            this.btnCheckIn.Name                 = "btnCheckIn";
            this.btnCheckIn.Size                 = new System.Drawing.Size(130, 50);
            this.btnCheckIn.TabIndex             = 2;
            this.btnCheckIn.Text                 = "Check In";
            this.btnCheckIn.Click               += new System.EventHandler(this.btnCheckIn_Click);
            //
            // pnlFeedback
            //
            this.pnlFeedback.Controls.Add(this.lblFeedback);
            this.pnlFeedback.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.pnlFeedback.Location  = new System.Drawing.Point(750, 44);
            this.pnlFeedback.Name      = "pnlFeedback";
            this.pnlFeedback.Size      = new System.Drawing.Size(218, 50);
            this.pnlFeedback.TabIndex  = 3;
            this.pnlFeedback.Visible   = false;
            //
            // lblFeedback
            //
            this.lblFeedback.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblFeedback.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFeedback.ForeColor = System.Drawing.Color.White;
            this.lblFeedback.Name      = "lblFeedback";
            this.lblFeedback.Size      = new System.Drawing.Size(218, 50);
            this.lblFeedback.TabIndex  = 0;
            this.lblFeedback.Text      = "";
            this.lblFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTodayTitle
            //
            this.lblTodayTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTodayTitle.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTodayTitle.Location  = new System.Drawing.Point(10, 202);
            this.lblTodayTitle.Name      = "lblTodayTitle";
            this.lblTodayTitle.Size      = new System.Drawing.Size(400, 28);
            this.lblTodayTitle.TabIndex  = 2;
            this.lblTodayTitle.Text      = "Today's Attendance";
            //
            // dgvToday
            //
            this.dgvToday.AllowUserToAddRows    = false;
            this.dgvToday.BackgroundColor       = System.Drawing.Color.White;
            this.dgvToday.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvToday.ColumnHeadersHeight   = 29;
            this.dgvToday.EnableHeadersVisualStyles = false;
            this.dgvToday.GridColor             = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvToday.Location              = new System.Drawing.Point(10, 236);
            this.dgvToday.MultiSelect           = false;
            this.dgvToday.Name                  = "dgvToday";
            this.dgvToday.ReadOnly              = true;
            this.dgvToday.RowHeadersVisible     = false;
            this.dgvToday.RowHeadersWidth       = 51;
            this.dgvToday.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToday.Size                  = new System.Drawing.Size(980, 380);
            this.dgvToday.TabIndex              = 3;
            this.dgvToday.CellFormatting       += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToday_CellFormatting);
            this.dgvToday.CellContentClick     += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToday_CellContentClick);
            this.dgvToday.DataBindingComplete  += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvToday_DataBindingComplete);
            //
            // panelStats
            //
            this.panelStats.Controls.Add(this.lblStatTodayName);
            this.panelStats.Controls.Add(this.lblStatTodayVal);
            this.panelStats.Controls.Add(this.lblStatWeekName);
            this.panelStats.Controls.Add(this.lblStatWeekVal);
            this.panelStats.Controls.Add(this.lblStatMonthName);
            this.panelStats.Controls.Add(this.lblStatMonthVal);
            this.panelStats.Controls.Add(this.btnViewHistory);
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelStats.Location  = new System.Drawing.Point(0, 626);
            this.panelStats.Name      = "panelStats";
            this.panelStats.Size      = new System.Drawing.Size(1000, 84);
            this.panelStats.TabIndex  = 4;
            //
            // lblStatTodayName
            //
            this.lblStatTodayName.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatTodayName.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblStatTodayName.Location  = new System.Drawing.Point(15, 10);
            this.lblStatTodayName.Name      = "lblStatTodayName";
            this.lblStatTodayName.Size      = new System.Drawing.Size(155, 18);
            this.lblStatTodayName.TabIndex  = 0;
            this.lblStatTodayName.Text      = "TODAY'S VISITS";
            //
            // lblStatTodayVal
            //
            this.lblStatTodayVal.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatTodayVal.ForeColor = System.Drawing.Color.FromArgb(0, 105, 110);
            this.lblStatTodayVal.Location  = new System.Drawing.Point(15, 28);
            this.lblStatTodayVal.Name      = "lblStatTodayVal";
            this.lblStatTodayVal.Size      = new System.Drawing.Size(155, 46);
            this.lblStatTodayVal.TabIndex  = 1;
            this.lblStatTodayVal.Text      = "0";
            //
            // lblStatWeekName
            //
            this.lblStatWeekName.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatWeekName.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblStatWeekName.Location  = new System.Drawing.Point(195, 10);
            this.lblStatWeekName.Name      = "lblStatWeekName";
            this.lblStatWeekName.Size      = new System.Drawing.Size(155, 18);
            this.lblStatWeekName.TabIndex  = 2;
            this.lblStatWeekName.Text      = "THIS WEEK";
            //
            // lblStatWeekVal
            //
            this.lblStatWeekVal.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatWeekVal.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblStatWeekVal.Location  = new System.Drawing.Point(195, 28);
            this.lblStatWeekVal.Name      = "lblStatWeekVal";
            this.lblStatWeekVal.Size      = new System.Drawing.Size(155, 46);
            this.lblStatWeekVal.TabIndex  = 3;
            this.lblStatWeekVal.Text      = "0";
            //
            // lblStatMonthName
            //
            this.lblStatMonthName.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatMonthName.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblStatMonthName.Location  = new System.Drawing.Point(375, 10);
            this.lblStatMonthName.Name      = "lblStatMonthName";
            this.lblStatMonthName.Size      = new System.Drawing.Size(155, 18);
            this.lblStatMonthName.TabIndex  = 4;
            this.lblStatMonthName.Text      = "THIS MONTH";
            //
            // lblStatMonthVal
            //
            this.lblStatMonthVal.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatMonthVal.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.lblStatMonthVal.Location  = new System.Drawing.Point(375, 28);
            this.lblStatMonthVal.Name      = "lblStatMonthVal";
            this.lblStatMonthVal.Size      = new System.Drawing.Size(155, 46);
            this.lblStatMonthVal.TabIndex  = 5;
            this.lblStatMonthVal.Text      = "0";
            //
            // btnViewHistory
            //
            this.btnViewHistory.BorderRadius         = 8;
            this.btnViewHistory.FillColor            = System.Drawing.Color.FromArgb(0, 105, 110);
            this.btnViewHistory.Font                 = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewHistory.ForeColor            = System.Drawing.Color.White;
            this.btnViewHistory.HoverState.FillColor = System.Drawing.Color.FromArgb(0, 77, 80);
            this.btnViewHistory.Location             = new System.Drawing.Point(565, 17);
            this.btnViewHistory.Name                 = "btnViewHistory";
            this.btnViewHistory.Size                 = new System.Drawing.Size(420, 50);
            this.btnViewHistory.TabIndex             = 6;
            this.btnViewHistory.Text                 = "View Full Attendance History";
            this.btnViewHistory.Click               += new System.EventHandler(this.btnViewHistory_Click);
            //
            // AttendanceForm
            //
            this.BackColor        = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize       = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelCheckIn);
            this.Controls.Add(this.lblTodayTitle);
            this.Controls.Add(this.dgvToday);
            this.Controls.Add(this.panelStats);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox      = false;
            this.Name             = "AttendanceForm";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text             = "Attendance";
            this.Load            += new System.EventHandler(this.AttendanceForm_Load);
            this.panelTopBar.ResumeLayout(false);
            this.panelCheckIn.ResumeLayout(false);
            this.pnlFeedback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToday)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel   panelTopBar;
        private System.Windows.Forms.Label     lblTitle;
        private Guna.UI2.WinForms.Guna2Button  btnClose;
        private Guna.UI2.WinForms.Guna2Panel   panelCheckIn;
        private System.Windows.Forms.Label     lblCheckInTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMemberInput;
        private Guna.UI2.WinForms.Guna2Button  btnCheckIn;
        private System.Windows.Forms.Panel     pnlFeedback;
        private System.Windows.Forms.Label     lblFeedback;
        private System.Windows.Forms.Label     lblTodayTitle;
        private System.Windows.Forms.DataGridView dgvToday;
        private System.Windows.Forms.Panel     panelStats;
        private System.Windows.Forms.Label     lblStatTodayName;
        private System.Windows.Forms.Label     lblStatTodayVal;
        private System.Windows.Forms.Label     lblStatWeekName;
        private System.Windows.Forms.Label     lblStatWeekVal;
        private System.Windows.Forms.Label     lblStatMonthName;
        private System.Windows.Forms.Label     lblStatMonthVal;
        private Guna.UI2.WinForms.Guna2Button  btnViewHistory;
    }
}
