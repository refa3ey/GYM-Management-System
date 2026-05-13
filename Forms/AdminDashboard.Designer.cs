namespace GYM_Desktop_app.Forms
{
    partial class AdminDashboard
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
            this.panelDivider = new System.Windows.Forms.Panel();
            this.btnManageMembers = new Guna.UI2.WinForms.Guna2Button();
            this.btnAttendance = new Guna.UI2.WinForms.Guna2Button();
            this.btnManagePlans = new Guna.UI2.WinForms.Guna2Button();
            this.btnManageTrainers = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayments = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panelTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.cardMembers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCardMembers = new System.Windows.Forms.Label();
            this.lblCardMembersVal = new System.Windows.Forms.Label();
            this.cardActive = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCardActive = new System.Windows.Forms.Label();
            this.lblCardActiveVal = new System.Windows.Forms.Label();
            this.cardRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCardRevenue = new System.Windows.Forms.Label();
            this.lblCardRevenueVal = new System.Windows.Forms.Label();
            this.cardNew = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCardNew = new System.Windows.Forms.Label();
            this.lblCardNewVal = new System.Windows.Forms.Label();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.dgvRecentMembers = new System.Windows.Forms.DataGridView();
            this.panelSidebar.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.cardMembers.SuspendLayout();
            this.cardActive.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Controls.Add(this.lblBrandSub);
            this.panelSidebar.Controls.Add(this.panelDivider);
            this.panelSidebar.Controls.Add(this.btnManageMembers);
            this.panelSidebar.Controls.Add(this.btnAttendance);
            this.panelSidebar.Controls.Add(this.btnManagePlans);
            this.panelSidebar.Controls.Add(this.btnManageTrainers);
            this.panelSidebar.Controls.Add(this.btnPayments);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnChangePassword);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(240, 700);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.panelSidebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            this.panelSidebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseUp);
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(0, 28);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(240, 40);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "GYM PRO";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblBrandSub.Location = new System.Drawing.Point(0, 66);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(240, 18);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "Management System";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.panelDivider.Location = new System.Drawing.Point(20, 93);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(200, 1);
            this.panelDivider.TabIndex = 2;
            // 
            // btnManageMembers
            // 
            this.btnManageMembers.BorderRadius = 8;
            this.btnManageMembers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnManageMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManageMembers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnManageMembers.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManageMembers.Location = new System.Drawing.Point(10, 105);
            this.btnManageMembers.Name = "btnManageMembers";
            this.btnManageMembers.Size = new System.Drawing.Size(220, 50);
            this.btnManageMembers.TabIndex = 3;
            this.btnManageMembers.Text = "  Members";
            this.btnManageMembers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageMembers.Click += new System.EventHandler(this.btnManageMembers_Click);
            //
            // btnAttendance
            //
            this.btnAttendance.BorderRadius = 8;
            this.btnAttendance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAttendance.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnAttendance.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAttendance.Location = new System.Drawing.Point(10, 165);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(220, 50);
            this.btnAttendance.TabIndex = 4;
            this.btnAttendance.Text = "  Attendance";
            this.btnAttendance.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            //
            // btnManagePlans
            // 
            this.btnManagePlans.BorderRadius = 8;
            this.btnManagePlans.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnManagePlans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManagePlans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManagePlans.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnManagePlans.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManagePlans.Location = new System.Drawing.Point(10, 225);
            this.btnManagePlans.Name = "btnManagePlans";
            this.btnManagePlans.Size = new System.Drawing.Size(220, 50);
            this.btnManagePlans.TabIndex = 5;
            this.btnManagePlans.Text = "  Plans";
            this.btnManagePlans.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManagePlans.Click += new System.EventHandler(this.btnManagePlans_Click);
            // 
            // btnManageTrainers
            // 
            this.btnManageTrainers.BorderRadius = 8;
            this.btnManageTrainers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnManageTrainers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageTrainers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManageTrainers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnManageTrainers.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManageTrainers.Location = new System.Drawing.Point(10, 285);
            this.btnManageTrainers.Name = "btnManageTrainers";
            this.btnManageTrainers.Size = new System.Drawing.Size(220, 50);
            this.btnManageTrainers.TabIndex = 6;
            this.btnManageTrainers.Text = "  Trainers";
            this.btnManageTrainers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageTrainers.Click += new System.EventHandler(this.btnManageTrainers_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BorderRadius = 8;
            this.btnPayments.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnPayments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPayments.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnPayments.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPayments.Location = new System.Drawing.Point(10, 345);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(220, 50);
            this.btnPayments.TabIndex = 7;
            this.btnPayments.Text = "  Payments";
            this.btnPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 8;
            this.btnReports.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnReports.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReports.Location = new System.Drawing.Point(10, 405);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 50);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "  Reports";
            this.btnReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            //
            // btnChangePassword
            //
            this.btnChangePassword.BorderRadius = 8;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangePassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnChangePassword.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangePassword.Location = new System.Drawing.Point(10, 465);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(220, 50);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "  Change Password";
            this.btnChangePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            //
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 625);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.lblPageTitle);
            this.panelTopBar.Controls.Add(this.lblWelcome);
            this.panelTopBar.Controls.Add(this.btnClose);
            this.panelTopBar.FillColor = System.Drawing.Color.White;
            this.panelTopBar.Location = new System.Drawing.Point(240, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(960, 65);
            this.panelTopBar.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 15);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(300, 35);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblWelcome.Location = new System.Drawing.Point(600, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Admin!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 20;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(920, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cardMembers
            // 
            this.cardMembers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cardMembers.BorderRadius = 12;
            this.cardMembers.BorderThickness = 1;
            this.cardMembers.Controls.Add(this.lblCardMembers);
            this.cardMembers.Controls.Add(this.lblCardMembersVal);
            this.cardMembers.FillColor = System.Drawing.Color.White;
            this.cardMembers.Location = new System.Drawing.Point(258, 85);
            this.cardMembers.Name = "cardMembers";
            this.cardMembers.Size = new System.Drawing.Size(205, 105);
            this.cardMembers.TabIndex = 2;
            // 
            // lblCardMembers
            // 
            this.lblCardMembers.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCardMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCardMembers.Location = new System.Drawing.Point(15, 15);
            this.lblCardMembers.Name = "lblCardMembers";
            this.lblCardMembers.Size = new System.Drawing.Size(185, 18);
            this.lblCardMembers.TabIndex = 0;
            this.lblCardMembers.Text = "TOTAL MEMBERS";
            // 
            // lblCardMembersVal
            // 
            this.lblCardMembersVal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCardMembersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.lblCardMembersVal.Location = new System.Drawing.Point(15, 38);
            this.lblCardMembersVal.Name = "lblCardMembersVal";
            this.lblCardMembersVal.Size = new System.Drawing.Size(185, 50);
            this.lblCardMembersVal.TabIndex = 1;
            this.lblCardMembersVal.Text = "0";
            // 
            // cardActive
            // 
            this.cardActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cardActive.BorderRadius = 12;
            this.cardActive.BorderThickness = 1;
            this.cardActive.Controls.Add(this.lblCardActive);
            this.cardActive.Controls.Add(this.lblCardActiveVal);
            this.cardActive.FillColor = System.Drawing.Color.White;
            this.cardActive.Location = new System.Drawing.Point(481, 85);
            this.cardActive.Name = "cardActive";
            this.cardActive.Size = new System.Drawing.Size(205, 105);
            this.cardActive.TabIndex = 3;
            // 
            // lblCardActive
            // 
            this.lblCardActive.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCardActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCardActive.Location = new System.Drawing.Point(15, 15);
            this.lblCardActive.Name = "lblCardActive";
            this.lblCardActive.Size = new System.Drawing.Size(185, 18);
            this.lblCardActive.TabIndex = 0;
            this.lblCardActive.Text = "ACTIVE MEMBERS";
            // 
            // lblCardActiveVal
            // 
            this.lblCardActiveVal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCardActiveVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCardActiveVal.Location = new System.Drawing.Point(15, 38);
            this.lblCardActiveVal.Name = "lblCardActiveVal";
            this.lblCardActiveVal.Size = new System.Drawing.Size(185, 50);
            this.lblCardActiveVal.TabIndex = 1;
            this.lblCardActiveVal.Text = "0";
            // 
            // cardRevenue
            // 
            this.cardRevenue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cardRevenue.BorderRadius = 12;
            this.cardRevenue.BorderThickness = 1;
            this.cardRevenue.Controls.Add(this.lblCardRevenue);
            this.cardRevenue.Controls.Add(this.lblCardRevenueVal);
            this.cardRevenue.FillColor = System.Drawing.Color.White;
            this.cardRevenue.Location = new System.Drawing.Point(704, 85);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new System.Drawing.Size(205, 105);
            this.cardRevenue.TabIndex = 4;
            // 
            // lblCardRevenue
            // 
            this.lblCardRevenue.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCardRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCardRevenue.Location = new System.Drawing.Point(15, 15);
            this.lblCardRevenue.Name = "lblCardRevenue";
            this.lblCardRevenue.Size = new System.Drawing.Size(185, 18);
            this.lblCardRevenue.TabIndex = 0;
            this.lblCardRevenue.Text = "REVENUE (MONTH)";
            // 
            // lblCardRevenueVal
            // 
            this.lblCardRevenueVal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCardRevenueVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblCardRevenueVal.Location = new System.Drawing.Point(15, 38);
            this.lblCardRevenueVal.Name = "lblCardRevenueVal";
            this.lblCardRevenueVal.Size = new System.Drawing.Size(185, 50);
            this.lblCardRevenueVal.TabIndex = 1;
            this.lblCardRevenueVal.Text = "$0";
            // 
            // cardNew
            // 
            this.cardNew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cardNew.BorderRadius = 12;
            this.cardNew.BorderThickness = 1;
            this.cardNew.Controls.Add(this.lblCardNew);
            this.cardNew.Controls.Add(this.lblCardNewVal);
            this.cardNew.FillColor = System.Drawing.Color.White;
            this.cardNew.Location = new System.Drawing.Point(927, 85);
            this.cardNew.Name = "cardNew";
            this.cardNew.Size = new System.Drawing.Size(205, 105);
            this.cardNew.TabIndex = 5;
            // 
            // lblCardNew
            // 
            this.lblCardNew.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCardNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCardNew.Location = new System.Drawing.Point(15, 15);
            this.lblCardNew.Name = "lblCardNew";
            this.lblCardNew.Size = new System.Drawing.Size(185, 18);
            this.lblCardNew.TabIndex = 0;
            this.lblCardNew.Text = "NEW THIS WEEK";
            // 
            // lblCardNewVal
            // 
            this.lblCardNewVal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCardNewVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblCardNewVal.Location = new System.Drawing.Point(15, 38);
            this.lblCardNewVal.Name = "lblCardNewVal";
            this.lblCardNewVal.Size = new System.Drawing.Size(185, 50);
            this.lblCardNewVal.TabIndex = 1;
            this.lblCardNewVal.Text = "0";
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(258, 208);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(300, 30);
            this.lblRecentTitle.TabIndex = 6;
            this.lblRecentTitle.Text = "Recent Members";
            // 
            // dgvRecentMembers
            // 
            this.dgvRecentMembers.AllowUserToAddRows = false;
            this.dgvRecentMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentMembers.ColumnHeadersHeight = 29;
            this.dgvRecentMembers.EnableHeadersVisualStyles = false;
            this.dgvRecentMembers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRecentMembers.Location = new System.Drawing.Point(258, 245);
            this.dgvRecentMembers.MultiSelect = false;
            this.dgvRecentMembers.Name = "dgvRecentMembers";
            this.dgvRecentMembers.ReadOnly = true;
            this.dgvRecentMembers.RowHeadersVisible = false;
            this.dgvRecentMembers.RowHeadersWidth = 51;
            this.dgvRecentMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentMembers.Size = new System.Drawing.Size(930, 425);
            this.dgvRecentMembers.TabIndex = 20;
            // 
            // AdminDashboard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.cardMembers);
            this.Controls.Add(this.cardActive);
            this.Controls.Add(this.cardRevenue);
            this.Controls.Add(this.cardNew);
            this.Controls.Add(this.lblRecentTitle);
            this.Controls.Add(this.dgvRecentMembers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.cardMembers.ResumeLayout(false);
            this.cardActive.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel    panelSidebar;
        private System.Windows.Forms.Label      lblBrand;
        private System.Windows.Forms.Label      lblBrandSub;
        private System.Windows.Forms.Panel      panelDivider;
        private Guna.UI2.WinForms.Guna2Button   btnManageMembers;
        private Guna.UI2.WinForms.Guna2Button   btnAttendance;
        private Guna.UI2.WinForms.Guna2Button   btnManagePlans;
        private Guna.UI2.WinForms.Guna2Button   btnManageTrainers;
        private Guna.UI2.WinForms.Guna2Button   btnPayments;
        private Guna.UI2.WinForms.Guna2Button   btnReports;
        private Guna.UI2.WinForms.Guna2Button   btnChangePassword;
        private Guna.UI2.WinForms.Guna2Button   btnLogout;
        private Guna.UI2.WinForms.Guna2Panel    panelTopBar;
        private System.Windows.Forms.Label      lblPageTitle;
        private System.Windows.Forms.Label      lblWelcome;
        private Guna.UI2.WinForms.Guna2Button   btnClose;
        private Guna.UI2.WinForms.Guna2Panel    cardMembers;
        private System.Windows.Forms.Label      lblCardMembers;
        private System.Windows.Forms.Label      lblCardMembersVal;
        private Guna.UI2.WinForms.Guna2Panel    cardActive;
        private System.Windows.Forms.Label      lblCardActive;
        private System.Windows.Forms.Label      lblCardActiveVal;
        private Guna.UI2.WinForms.Guna2Panel    cardRevenue;
        private System.Windows.Forms.Label      lblCardRevenue;
        private System.Windows.Forms.Label      lblCardRevenueVal;
        private Guna.UI2.WinForms.Guna2Panel    cardNew;
        private System.Windows.Forms.Label      lblCardNew;
        private System.Windows.Forms.Label      lblCardNewVal;
        private System.Windows.Forms.Label      lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvRecentMembers;
    }
}
