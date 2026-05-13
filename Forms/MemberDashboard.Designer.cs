namespace GYM_Desktop_app.Forms
{
    partial class MemberDashboard
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
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.btnViewSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panelTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panelInfoCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblPlanLabel = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblExpiryLabel = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.panelInfoCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Controls.Add(this.lblBrandSub);
            this.panelSidebar.Controls.Add(this.btnViewSchedule);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(240, 600);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.panelSidebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            this.panelSidebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseUp);
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.Teal;
            this.lblBrand.Location = new System.Drawing.Point(0, 28);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(240, 40);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "GYM PRO";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.Teal;
            this.lblBrandSub.Location = new System.Drawing.Point(0, 66);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(240, 18);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "Member Portal";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.BorderRadius = 8;
            this.btnViewSchedule.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnViewSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewSchedule.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnViewSchedule.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewSchedule.Location = new System.Drawing.Point(10, 110);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(220, 50);
            this.btnViewSchedule.TabIndex = 2;
            this.btnViewSchedule.Text = "  Workout Schedule";
            this.btnViewSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 530);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.lblWelcome);
            this.panelTopBar.Controls.Add(this.btnClose);
            this.panelTopBar.FillColor = System.Drawing.Color.White;
            this.panelTopBar.Location = new System.Drawing.Point(241, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(754, 68);
            this.panelTopBar.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblWelcome.Location = new System.Drawing.Point(25, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(600, 35);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome!";
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 20;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(720, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelInfoCard
            // 
            this.panelInfoCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelInfoCard.BorderRadius = 12;
            this.panelInfoCard.BorderThickness = 1;
            this.panelInfoCard.Controls.Add(this.lblInfoTitle);
            this.panelInfoCard.Controls.Add(this.lblPlanLabel);
            this.panelInfoCard.Controls.Add(this.lblPlan);
            this.panelInfoCard.Controls.Add(this.lblExpiryLabel);
            this.panelInfoCard.Controls.Add(this.lblExpiry);
            this.panelInfoCard.Controls.Add(this.lblStatusLabel);
            this.panelInfoCard.Controls.Add(this.lblStatus);
            this.panelInfoCard.FillColor = System.Drawing.Color.White;
            this.panelInfoCard.Location = new System.Drawing.Point(270, 95);
            this.panelInfoCard.Name = "panelInfoCard";
            this.panelInfoCard.Size = new System.Drawing.Size(700, 220);
            this.panelInfoCard.TabIndex = 2;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(25, 18);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(650, 30);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Membership Information";
            // 
            // lblPlanLabel
            // 
            this.lblPlanLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPlanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblPlanLabel.Location = new System.Drawing.Point(25, 65);
            this.lblPlanLabel.Name = "lblPlanLabel";
            this.lblPlanLabel.Size = new System.Drawing.Size(165, 28);
            this.lblPlanLabel.TabIndex = 1;
            this.lblPlanLabel.Text = "Membership Plan";
            this.lblPlanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlan
            // 
            this.lblPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPlan.Location = new System.Drawing.Point(200, 65);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(430, 28);
            this.lblPlan.TabIndex = 2;
            this.lblPlan.Text = "—";
            this.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpiryLabel
            // 
            this.lblExpiryLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblExpiryLabel.Location = new System.Drawing.Point(25, 115);
            this.lblExpiryLabel.Name = "lblExpiryLabel";
            this.lblExpiryLabel.Size = new System.Drawing.Size(165, 28);
            this.lblExpiryLabel.TabIndex = 3;
            this.lblExpiryLabel.Text = "Expiry Date";
            this.lblExpiryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblExpiry.Location = new System.Drawing.Point(200, 115);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(430, 28);
            this.lblExpiry.TabIndex = 4;
            this.lblExpiry.Text = "—";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(25, 165);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(165, 28);
            this.lblStatusLabel.TabIndex = 5;
            this.lblStatusLabel.Text = "Status";
            this.lblStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblStatus.Location = new System.Drawing.Point(200, 165);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(430, 28);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "—";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MemberDashboard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelInfoCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MemberDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Dashboard";
            this.Load += new System.EventHandler(this.MemberDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.panelInfoCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel  panelSidebar;
        private System.Windows.Forms.Label    lblBrand;
        private System.Windows.Forms.Label    lblBrandSub;
        private Guna.UI2.WinForms.Guna2Button btnViewSchedule;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel  panelTopBar;
        private System.Windows.Forms.Label    lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel  panelInfoCard;
        private System.Windows.Forms.Label    lblInfoTitle;
        private System.Windows.Forms.Label    lblPlanLabel;
        private System.Windows.Forms.Label    lblPlan;
        private System.Windows.Forms.Label    lblExpiryLabel;
        private System.Windows.Forms.Label    lblExpiry;
        private System.Windows.Forms.Label    lblStatusLabel;
        private System.Windows.Forms.Label    lblStatus;
    }
}
