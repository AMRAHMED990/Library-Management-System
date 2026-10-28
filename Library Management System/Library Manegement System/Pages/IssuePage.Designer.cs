namespace Library_Manegement_System
{
    partial class IssuePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblIssueTitle = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnIssue = new System.Windows.Forms.Button();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblReturnTitle = new System.Windows.Forms.Label();
            this.lblSelectedLoan = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblSearch.Location = new System.Drawing.Point(0, 10);
            this.lblSearch.Text = "Search";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(58, 4);
            this.txtSearch.Size = new System.Drawing.Size(260, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(334, 4);
            this.cmbFilter.Size = new System.Drawing.Size(150, 31);
            this.cmbFilter.Items.AddRange(new object[] {
            "All",
            "On loan",
            "Overdue",
            "Returned"});
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.TabIndex = 2;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // dgvLoans
            // 
            this.dgvLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLoans.Location = new System.Drawing.Point(0, 44);
            this.dgvLoans.Size = new System.Drawing.Size(630, 576);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.TabIndex = 3;
            this.dgvLoans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoans_CellClick);
            this.dgvLoans.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLoans_CellFormatting);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblIssueTitle);
            this.pnlDetails.Controls.Add(this.lblStudent);
            this.pnlDetails.Controls.Add(this.cmbStudent);
            this.pnlDetails.Controls.Add(this.lblBook);
            this.pnlDetails.Controls.Add(this.cmbBook);
            this.pnlDetails.Controls.Add(this.lblIssueDate);
            this.pnlDetails.Controls.Add(this.dtpIssueDate);
            this.pnlDetails.Controls.Add(this.lblDueDate);
            this.pnlDetails.Controls.Add(this.dtpDueDate);
            this.pnlDetails.Controls.Add(this.btnIssue);
            this.pnlDetails.Controls.Add(this.pnlLine);
            this.pnlDetails.Controls.Add(this.lblReturnTitle);
            this.pnlDetails.Controls.Add(this.lblSelectedLoan);
            this.pnlDetails.Controls.Add(this.btnReturn);
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.Location = new System.Drawing.Point(650, 0);
            this.pnlDetails.Size = new System.Drawing.Size(350, 620);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.TabIndex = 4;
            // 
            // lblIssueTitle
            // 
            this.lblIssueTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblIssueTitle.Location = new System.Drawing.Point(20, 16);
            this.lblIssueTitle.Text = "Issue a book";
            this.lblIssueTitle.AutoSize = true;
            this.lblIssueTitle.Name = "lblIssueTitle";
            this.lblIssueTitle.TabIndex = 5;
            // 
            // lblStudent
            // 
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblStudent.Location = new System.Drawing.Point(20, 62);
            this.lblStudent.Text = "Student";
            this.lblStudent.AutoSize = true;
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.TabIndex = 6;
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(20, 83);
            this.cmbStudent.Size = new System.Drawing.Size(300, 31);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.TabIndex = 7;
            // 
            // lblBook
            // 
            this.lblBook.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblBook.Location = new System.Drawing.Point(20, 120);
            this.lblBook.Text = "Book (only books with a free copy)";
            this.lblBook.AutoSize = true;
            this.lblBook.Name = "lblBook";
            this.lblBook.TabIndex = 8;
            // 
            // cmbBook
            // 
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(20, 141);
            this.cmbBook.Size = new System.Drawing.Size(300, 31);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.TabIndex = 9;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblIssueDate.Location = new System.Drawing.Point(20, 178);
            this.lblIssueDate.Text = "Issue date";
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.TabIndex = 10;
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CustomFormat = "dd MMM yyyy";
            this.dtpIssueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(20, 199);
            this.dtpIssueDate.Size = new System.Drawing.Size(145, 30);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.TabIndex = 11;
            this.dtpIssueDate.ValueChanged += new System.EventHandler(this.dtpIssueDate_ValueChanged);
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblDueDate.Location = new System.Drawing.Point(175, 178);
            this.lblDueDate.Text = "Due date";
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.TabIndex = 12;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd MMM yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(175, 199);
            this.dtpDueDate.Size = new System.Drawing.Size(145, 30);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.TabIndex = 13;
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.FlatAppearance.BorderSize = 0;
            this.btnIssue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(20, 246);
            this.btnIssue.Size = new System.Drawing.Size(300, 38);
            this.btnIssue.Text = "Issue book";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.TabIndex = 14;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.pnlLine.Location = new System.Drawing.Point(20, 306);
            this.pnlLine.Size = new System.Drawing.Size(300, 1);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.TabIndex = 15;
            // 
            // lblReturnTitle
            // 
            this.lblReturnTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblReturnTitle.Location = new System.Drawing.Point(20, 324);
            this.lblReturnTitle.Text = "Return a book";
            this.lblReturnTitle.AutoSize = true;
            this.lblReturnTitle.Name = "lblReturnTitle";
            this.lblReturnTitle.TabIndex = 16;
            // 
            // lblSelectedLoan
            // 
            this.lblSelectedLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedLoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblSelectedLoan.Location = new System.Drawing.Point(20, 362);
            this.lblSelectedLoan.Text = "Click a loan in the list to return it.";
            this.lblSelectedLoan.AutoSize = false;
            this.lblSelectedLoan.Size = new System.Drawing.Size(300, 80);
            this.lblSelectedLoan.Name = "lblSelectedLoan";
            this.lblSelectedLoan.TabIndex = 17;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.White;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.btnReturn.FlatAppearance.BorderSize = 1;
            this.btnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.btnReturn.Location = new System.Drawing.Point(20, 450);
            this.btnReturn.Size = new System.Drawing.Size(300, 38);
            this.btnReturn.Text = "Return book";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // IssuePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.pnlDetails);
            this.Name = "IssuePage";
            this.Size = new System.Drawing.Size(1000, 620);
            this.Load += new System.EventHandler(this.IssuePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlLine.ResumeLayout(false);
            this.pnlLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblIssueTitle;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblReturnTitle;
        private System.Windows.Forms.Label lblSelectedLoan;
        private System.Windows.Forms.Button btnReturn;
    }
}
