namespace GYM_Desktop_app.Forms
{
    partial class CheckInStationForm
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
            this.components      = new System.ComponentModel.Container();
            this.timerClock      = new System.Windows.Forms.Timer(this.components);
            this.timerRefocus    = new System.Windows.Forms.Timer(this.components);
            this.timerRevert     = new System.Windows.Forms.Timer(this.components);
            this.pnlTopBar       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStationTitle = new System.Windows.Forms.Label();
            this.lblDateTime     = new System.Windows.Forms.Label();
            this.btnExitStation  = new Guna.UI2.WinForms.Guna2Button();
            this.pnlModeReady    = new System.Windows.Forms.Panel();
            this.lblPrompt       = new System.Windows.Forms.Label();
            this.lblSubtitle     = new System.Windows.Forms.Label();
            this.txtScan         = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblScannerHint  = new System.Windows.Forms.Label();
            this.lblTodayCount   = new System.Windows.Forms.Label();
            this.pnlModeResult   = new System.Windows.Forms.Panel();
            this.lblResultIcon   = new System.Windows.Forms.Label();
            this.lblResultName   = new System.Windows.Forms.Label();
            this.lblResultDetails = new System.Windows.Forms.Label();
            this.lblResultTime   = new System.Windows.Forms.Label();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.pnlTopBar.SuspendLayout();
            this.pnlModeReady.SuspendLayout();
            this.pnlModeResult.SuspendLayout();
            this.SuspendLayout();
            //
            // timerClock
            //
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            //
            // timerRefocus
            //
            this.timerRefocus.Interval = 200;
            this.timerRefocus.Tick += new System.EventHandler(this.timerRefocus_Tick);
            //
            // timerRevert
            //
            this.timerRevert.Interval = 3000;
            this.timerRevert.Tick += new System.EventHandler(this.timerRevert_Tick);
            //
            // pnlTopBar
            //
            this.pnlTopBar.Controls.Add(this.lblStationTitle);
            this.pnlTopBar.Controls.Add(this.lblDateTime);
            this.pnlTopBar.Controls.Add(this.btnExitStation);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.FillColor = System.Drawing.Color.FromArgb(0, 77, 80);
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1920, 80);
            this.pnlTopBar.TabIndex = 0;
            //
            // lblStationTitle
            //
            this.lblStationTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStationTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStationTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblStationTitle.ForeColor = System.Drawing.Color.White;
            this.lblStationTitle.Location = new System.Drawing.Point(300, 18);
            this.lblStationTitle.Name = "lblStationTitle";
            this.lblStationTitle.Size = new System.Drawing.Size(900, 44);
            this.lblStationTitle.TabIndex = 0;
            this.lblStationTitle.Text = "GYM PRO — Check-In Station";
            this.lblStationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDateTime
            //
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1300, 24);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(450, 32);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnExitStation
            //
            this.btnExitStation.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnExitStation.BorderRadius = 8;
            this.btnExitStation.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExitStation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExitStation.ForeColor = System.Drawing.Color.White;
            this.btnExitStation.HoverState.FillColor = System.Drawing.Color.FromArgb(180, 30, 45);
            this.btnExitStation.Location = new System.Drawing.Point(1770, 22);
            this.btnExitStation.Name = "btnExitStation";
            this.btnExitStation.Size = new System.Drawing.Size(130, 36);
            this.btnExitStation.TabIndex = 2;
            this.btnExitStation.Text = "Exit Station";
            this.btnExitStation.Click += new System.EventHandler(this.btnExitStation_Click);
            //
            // pnlModeReady
            //
            this.pnlModeReady.BackColor = System.Drawing.Color.White;
            this.pnlModeReady.Controls.Add(this.lblPrompt);
            this.pnlModeReady.Controls.Add(this.lblSubtitle);
            this.pnlModeReady.Controls.Add(this.txtScan);
            this.pnlModeReady.Controls.Add(this.lblScannerHint);
            this.pnlModeReady.Controls.Add(this.lblTodayCount);
            this.pnlModeReady.Location = new System.Drawing.Point(0, 80);
            this.pnlModeReady.Name = "pnlModeReady";
            this.pnlModeReady.Size = new System.Drawing.Size(1920, 1000);
            this.pnlModeReady.TabIndex = 1;
            //
            // lblPrompt
            //
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(0, 105, 110);
            this.lblPrompt.Location = new System.Drawing.Point(60, 300);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(1800, 70);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Scan your QR code or enter your Member ID";
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitle
            //
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblSubtitle.Location = new System.Drawing.Point(60, 378);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(1800, 42);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Or type your number and press Enter";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtScan
            //
            this.txtScan.BorderRadius = 12;
            this.txtScan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(0, 105, 110);
            this.txtScan.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.txtScan.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtScan.Location = new System.Drawing.Point(560, 440);
            this.txtScan.Name = "txtScan";
            this.txtScan.PlaceholderText = "...";
            this.txtScan.Size = new System.Drawing.Size(800, 75);
            this.txtScan.TabIndex = 2;
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            //
            // lblScannerHint
            //
            this.lblScannerHint.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblScannerHint.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblScannerHint.Location = new System.Drawing.Point(60, 880);
            this.lblScannerHint.Name = "lblScannerHint";
            this.lblScannerHint.Size = new System.Drawing.Size(1800, 32);
            this.lblScannerHint.TabIndex = 3;
            this.lblScannerHint.Text = "USB scanner works automatically — just scan to check in";
            this.lblScannerHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTodayCount
            //
            this.lblTodayCount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTodayCount.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblTodayCount.Location = new System.Drawing.Point(1570, 920);
            this.lblTodayCount.Name = "lblTodayCount";
            this.lblTodayCount.Size = new System.Drawing.Size(320, 32);
            this.lblTodayCount.TabIndex = 4;
            this.lblTodayCount.Text = "Check-ins today: 0";
            this.lblTodayCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // pnlModeResult
            //
            this.pnlModeResult.BackColor = System.Drawing.Color.White;
            this.pnlModeResult.Controls.Add(this.lblResultIcon);
            this.pnlModeResult.Controls.Add(this.lblResultName);
            this.pnlModeResult.Controls.Add(this.lblResultDetails);
            this.pnlModeResult.Controls.Add(this.lblResultTime);
            this.pnlModeResult.Controls.Add(this.lblResultMessage);
            this.pnlModeResult.Location = new System.Drawing.Point(0, 80);
            this.pnlModeResult.Name = "pnlModeResult";
            this.pnlModeResult.Size = new System.Drawing.Size(1920, 1000);
            this.pnlModeResult.TabIndex = 2;
            this.pnlModeResult.Visible = false;
            //
            // lblResultIcon
            //
            this.lblResultIcon.Font = new System.Drawing.Font("Segoe UI", 100F, System.Drawing.FontStyle.Bold);
            this.lblResultIcon.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblResultIcon.Location = new System.Drawing.Point(760, 80);
            this.lblResultIcon.Name = "lblResultIcon";
            this.lblResultIcon.Size = new System.Drawing.Size(400, 260);
            this.lblResultIcon.TabIndex = 0;
            this.lblResultIcon.Text = "✓";
            this.lblResultIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblResultName
            //
            this.lblResultName.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblResultName.ForeColor = System.Drawing.Color.FromArgb(20, 100, 35);
            this.lblResultName.Location = new System.Drawing.Point(60, 360);
            this.lblResultName.Name = "lblResultName";
            this.lblResultName.Size = new System.Drawing.Size(1800, 110);
            this.lblResultName.TabIndex = 1;
            this.lblResultName.Text = "";
            this.lblResultName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblResultDetails
            //
            this.lblResultDetails.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblResultDetails.ForeColor = System.Drawing.Color.FromArgb(40, 80, 40);
            this.lblResultDetails.Location = new System.Drawing.Point(60, 480);
            this.lblResultDetails.Name = "lblResultDetails";
            this.lblResultDetails.Size = new System.Drawing.Size(1800, 42);
            this.lblResultDetails.TabIndex = 2;
            this.lblResultDetails.Text = "";
            this.lblResultDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblResultTime
            //
            this.lblResultTime.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblResultTime.ForeColor = System.Drawing.Color.FromArgb(60, 100, 60);
            this.lblResultTime.Location = new System.Drawing.Point(60, 534);
            this.lblResultTime.Name = "lblResultTime";
            this.lblResultTime.Size = new System.Drawing.Size(1800, 38);
            this.lblResultTime.TabIndex = 3;
            this.lblResultTime.Text = "";
            this.lblResultTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblResultMessage
            //
            this.lblResultMessage.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblResultMessage.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblResultMessage.Location = new System.Drawing.Point(60, 588);
            this.lblResultMessage.Name = "lblResultMessage";
            this.lblResultMessage.Size = new System.Drawing.Size(1800, 50);
            this.lblResultMessage.TabIndex = 4;
            this.lblResultMessage.Text = "";
            this.lblResultMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // CheckInStationForm
            //
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlModeResult);
            this.Controls.Add(this.pnlModeReady);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckInStationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check-In Station";
            this.Load += new System.EventHandler(this.CheckInStationForm_Load);
            this.Resize += new System.EventHandler(this.CheckInStationForm_Resize);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlModeReady.ResumeLayout(false);
            this.pnlModeResult.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer       timerClock;
        private System.Windows.Forms.Timer       timerRefocus;
        private System.Windows.Forms.Timer       timerRevert;
        private Guna.UI2.WinForms.Guna2Panel     pnlTopBar;
        private System.Windows.Forms.Label       lblStationTitle;
        private System.Windows.Forms.Label       lblDateTime;
        private Guna.UI2.WinForms.Guna2Button    btnExitStation;
        private System.Windows.Forms.Panel       pnlModeReady;
        private System.Windows.Forms.Label       lblPrompt;
        private System.Windows.Forms.Label       lblSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox   txtScan;
        private System.Windows.Forms.Label       lblScannerHint;
        private System.Windows.Forms.Label       lblTodayCount;
        private System.Windows.Forms.Panel       pnlModeResult;
        private System.Windows.Forms.Label       lblResultIcon;
        private System.Windows.Forms.Label       lblResultName;
        private System.Windows.Forms.Label       lblResultDetails;
        private System.Windows.Forms.Label       lblResultTime;
        private System.Windows.Forms.Label       lblResultMessage;
    }
}
