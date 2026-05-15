namespace GYM_Desktop_app.Forms
{
    partial class AttendanceHistoryForm
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
            this.panelTopBar    = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.btnClose       = new Guna.UI2.WinForms.Guna2Button();
            this.panelFilter    = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFrom        = new System.Windows.Forms.Label();
            this.dtpFrom        = new System.Windows.Forms.DateTimePicker();
            this.lblTo          = new System.Windows.Forms.Label();
            this.dtpTo          = new System.Windows.Forms.DateTimePicker();
            this.lblMemberLbl   = new System.Windows.Forms.Label();
            this.cmbMember      = new System.Windows.Forms.ComboBox();
            this.btnApply       = new Guna.UI2.WinForms.Guna2Button();
            this.dgvHistory     = new System.Windows.Forms.DataGridView();
            this.panelFooter    = new System.Windows.Forms.Panel();
            this.lblSummary     = new System.Windows.Forms.Label();
            this.btnExport      = new Guna.UI2.WinForms.Guna2Button();
            this.panelTopBar.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTopBar
            //
            this.panelTopBar.Controls.Add(this.lblTitle);
            this.panelTopBar.Controls.Add(this.btnClose);
            this.panelTopBar.FillColor = System.Drawing.Color.White;
            this.panelTopBar.Location  = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name      = "panelTopBar";
            this.panelTopBar.Size      = new System.Drawing.Size(1100, 65);
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
            this.lblTitle.Size      = new System.Drawing.Size(500, 32);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "Attendance History";
            //
            // btnClose
            //
            this.btnClose.BorderRadius = 20;
            this.btnClose.FillColor    = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.Font         = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor    = System.Drawing.Color.White;
            this.btnClose.Location     = new System.Drawing.Point(1060, 18);
            this.btnClose.Name         = "btnClose";
            this.btnClose.Size         = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex     = 1;
            this.btnClose.Text         = "✕";
            this.btnClose.Click       += new System.EventHandler(this.btnClose_Click);
            //
            // panelFilter
            //
            this.panelFilter.Controls.Add(this.lblFrom);
            this.panelFilter.Controls.Add(this.dtpFrom);
            this.panelFilter.Controls.Add(this.lblTo);
            this.panelFilter.Controls.Add(this.dtpTo);
            this.panelFilter.Controls.Add(this.lblMemberLbl);
            this.panelFilter.Controls.Add(this.cmbMember);
            this.panelFilter.Controls.Add(this.btnApply);
            this.panelFilter.BorderColor     = System.Drawing.Color.FromArgb(230, 230, 230);
            this.panelFilter.BorderRadius    = 12;
            this.panelFilter.BorderThickness = 1;
            this.panelFilter.FillColor       = System.Drawing.Color.White;
            this.panelFilter.Location        = new System.Drawing.Point(10, 75);
            this.panelFilter.Name            = "panelFilter";
            this.panelFilter.Size            = new System.Drawing.Size(1080, 80);
            this.panelFilter.TabIndex        = 1;
            //
            // lblFrom
            //
            this.lblFrom.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblFrom.Location  = new System.Drawing.Point(18, 26);
            this.lblFrom.Name      = "lblFrom";
            this.lblFrom.Size      = new System.Drawing.Size(38, 22);
            this.lblFrom.TabIndex  = 0;
            this.lblFrom.Text      = "From";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpFrom
            //
            this.dtpFrom.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(62, 22);
            this.dtpFrom.Name     = "dtpFrom";
            this.dtpFrom.Size     = new System.Drawing.Size(155, 23);
            this.dtpFrom.TabIndex = 1;
            //
            // lblTo
            //
            this.lblTo.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblTo.Location  = new System.Drawing.Point(230, 26);
            this.lblTo.Name      = "lblTo";
            this.lblTo.Size      = new System.Drawing.Size(22, 22);
            this.lblTo.TabIndex  = 2;
            this.lblTo.Text      = "To";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpTo
            //
            this.dtpTo.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(258, 22);
            this.dtpTo.Name     = "dtpTo";
            this.dtpTo.Size     = new System.Drawing.Size(155, 23);
            this.dtpTo.TabIndex = 3;
            //
            // lblMemberLbl
            //
            this.lblMemberLbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMemberLbl.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblMemberLbl.Location  = new System.Drawing.Point(430, 26);
            this.lblMemberLbl.Name      = "lblMemberLbl";
            this.lblMemberLbl.Size      = new System.Drawing.Size(60, 22);
            this.lblMemberLbl.TabIndex  = 4;
            this.lblMemberLbl.Text      = "Member";
            this.lblMemberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbMember
            //
            this.cmbMember.DropDownStyle  = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMember.Location       = new System.Drawing.Point(496, 22);
            this.cmbMember.Name           = "cmbMember";
            this.cmbMember.Size           = new System.Drawing.Size(235, 25);
            this.cmbMember.TabIndex       = 5;
            //
            // btnApply
            //
            this.btnApply.BorderRadius         = 8;
            this.btnApply.FillColor            = System.Drawing.Color.FromArgb(0, 105, 110);
            this.btnApply.Font                 = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor            = System.Drawing.Color.White;
            this.btnApply.HoverState.FillColor = System.Drawing.Color.FromArgb(0, 77, 80);
            this.btnApply.Location             = new System.Drawing.Point(748, 16);
            this.btnApply.Name                 = "btnApply";
            this.btnApply.Size                 = new System.Drawing.Size(120, 46);
            this.btnApply.TabIndex             = 6;
            this.btnApply.Text                 = "Apply Filter";
            this.btnApply.Click               += new System.EventHandler(this.btnApply_Click);
            //
            // dgvHistory
            //
            this.dgvHistory.AllowUserToAddRows    = false;
            this.dgvHistory.BackgroundColor       = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeight   = 29;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.GridColor             = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvHistory.Location              = new System.Drawing.Point(10, 165);
            this.dgvHistory.MultiSelect           = false;
            this.dgvHistory.Name                  = "dgvHistory";
            this.dgvHistory.ReadOnly              = true;
            this.dgvHistory.RowHeadersVisible     = false;
            this.dgvHistory.RowHeadersWidth       = 51;
            this.dgvHistory.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size                  = new System.Drawing.Size(1080, 430);
            this.dgvHistory.TabIndex              = 2;
            this.dgvHistory.CellFormatting       += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistory_CellFormatting);
            this.dgvHistory.DataBindingComplete  += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvHistory_DataBindingComplete);
            //
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.lblSummary);
            this.panelFooter.Controls.Add(this.btnExport);
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Location  = new System.Drawing.Point(0, 605);
            this.panelFooter.Name      = "panelFooter";
            this.panelFooter.Size      = new System.Drawing.Size(1100, 65);
            this.panelFooter.TabIndex  = 3;
            //
            // lblSummary
            //
            this.lblSummary.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblSummary.Location  = new System.Drawing.Point(18, 22);
            this.lblSummary.Name      = "lblSummary";
            this.lblSummary.Size      = new System.Drawing.Size(750, 22);
            this.lblSummary.TabIndex  = 0;
            this.lblSummary.Text      = "Total: 0 visits";
            //
            // btnExport
            //
            this.btnExport.BorderRadius         = 8;
            this.btnExport.FillColor            = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExport.Font                 = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor            = System.Drawing.Color.White;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 130, 55);
            this.btnExport.Location             = new System.Drawing.Point(955, 12);
            this.btnExport.Name                 = "btnExport";
            this.btnExport.Size                 = new System.Drawing.Size(130, 42);
            this.btnExport.TabIndex             = 1;
            this.btnExport.Text                 = "Export Excel";
            this.btnExport.Click               += new System.EventHandler(this.btnExport_Click);
            //
            // AttendanceHistoryForm
            //
            this.BackColor        = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize       = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.panelFooter);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox      = false;
            this.Name             = "AttendanceHistoryForm";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text             = "Attendance History";
            this.Load            += new System.EventHandler(this.AttendanceHistoryForm_Load);
            this.panelTopBar.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel   panelTopBar;
        private System.Windows.Forms.Label     lblTitle;
        private Guna.UI2.WinForms.Guna2Button  btnClose;
        private Guna.UI2.WinForms.Guna2Panel   panelFilter;
        private System.Windows.Forms.Label     lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label     lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label     lblMemberLbl;
        private System.Windows.Forms.ComboBox  cmbMember;
        private Guna.UI2.WinForms.Guna2Button  btnApply;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel     panelFooter;
        private System.Windows.Forms.Label     lblSummary;
        private Guna.UI2.WinForms.Guna2Button  btnExport;
    }
}
