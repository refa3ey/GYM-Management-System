namespace GYM_Desktop_app.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnManageMembers = new System.Windows.Forms.Button();
            this.btnManagePlans = new System.Windows.Forms.Button();
            this.btnManageTrainers = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblWelcome
            //
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Teal;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Admin!";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(200, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ADMIN CONTROL PANEL";
            //
            // btnManageMembers
            //
            this.btnManageMembers.BackColor = System.Drawing.Color.Teal;
            this.btnManageMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageMembers.ForeColor = System.Drawing.Color.White;
            this.btnManageMembers.Location = new System.Drawing.Point(120, 130);
            this.btnManageMembers.Name = "btnManageMembers";
            this.btnManageMembers.Size = new System.Drawing.Size(220, 60);
            this.btnManageMembers.TabIndex = 2;
            this.btnManageMembers.Text = "Manage Members";
            this.btnManageMembers.UseVisualStyleBackColor = false;
            this.btnManageMembers.Click += new System.EventHandler(this.btnManageMembers_Click);
            //
            // btnManagePlans
            //
            this.btnManagePlans.BackColor = System.Drawing.Color.Teal;
            this.btnManagePlans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagePlans.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePlans.ForeColor = System.Drawing.Color.White;
            this.btnManagePlans.Location = new System.Drawing.Point(360, 130);
            this.btnManagePlans.Name = "btnManagePlans";
            this.btnManagePlans.Size = new System.Drawing.Size(220, 60);
            this.btnManagePlans.TabIndex = 3;
            this.btnManagePlans.Text = "Manage Plans";
            this.btnManagePlans.UseVisualStyleBackColor = false;
            this.btnManagePlans.Click += new System.EventHandler(this.btnManagePlans_Click);
            //
            // btnManageTrainers
            //
            this.btnManageTrainers.BackColor = System.Drawing.Color.Teal;
            this.btnManageTrainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageTrainers.ForeColor = System.Drawing.Color.White;
            this.btnManageTrainers.Location = new System.Drawing.Point(120, 210);
            this.btnManageTrainers.Name = "btnManageTrainers";
            this.btnManageTrainers.Size = new System.Drawing.Size(220, 60);
            this.btnManageTrainers.TabIndex = 4;
            this.btnManageTrainers.Text = "Manage Trainers";
            this.btnManageTrainers.UseVisualStyleBackColor = false;
            this.btnManageTrainers.Click += new System.EventHandler(this.btnManageTrainers_Click);
            //
            // btnPayments
            //
            this.btnPayments.BackColor = System.Drawing.Color.Teal;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(360, 210);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(220, 60);
            this.btnPayments.TabIndex = 5;
            this.btnPayments.Text = "Payments";
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            //
            // btnReports
            //
            this.btnReports.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(120, 290);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 60);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(360, 290);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 60);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // AdminDashboard
            //
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnManageMembers);
            this.Controls.Add(this.btnManagePlans);
            this.Controls.Add(this.btnManageTrainers);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard - Gym System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnManageMembers;
        private System.Windows.Forms.Button btnManagePlans;
        private System.Windows.Forms.Button btnManageTrainers;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
    }
}
