namespace Library_Manegement_System
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblLogoSub = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnFines = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLibrarians = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 80);
            this.pnlContent.Size = new System.Drawing.Size(1080, 720);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1080, 80);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblPageTitle.Location = new System.Drawing.Point(24, 22);
            this.lblPageTitle.Text = "Dashboard";
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblUser.Location = new System.Drawing.Point(760, 32);
            this.lblUser.Text = "Signed in as";
            this.lblUser.AutoSize = false;
            this.lblUser.Size = new System.Drawing.Size(296, 20);
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Name = "lblUser";
            this.lblUser.TabIndex = 3;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Controls.Add(this.lblLogoSub);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnBooks);
            this.pnlSidebar.Controls.Add(this.btnStudents);
            this.pnlSidebar.Controls.Add(this.btnIssue);
            this.pnlSidebar.Controls.Add(this.btnFines);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnLibrarians);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(220, 800);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.TabIndex = 4;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(22, 26);
            this.lblLogo.Text = "Library";
            this.lblLogo.AutoSize = true;
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.TabIndex = 5;
            // 
            // lblLogoSub
            // 
            this.lblLogoSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.lblLogoSub.Location = new System.Drawing.Point(24, 52);
            this.lblLogoSub.Text = "Management System";
            this.lblLogoSub.AutoSize = true;
            this.lblLogoSub.Name = "lblLogoSub";
            this.lblLogoSub.TabIndex = 6;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnDashboard.Location = new System.Drawing.Point(0, 110);
            this.btnDashboard.Size = new System.Drawing.Size(220, 46);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnBooks.Location = new System.Drawing.Point(0, 158);
            this.btnBooks.Size = new System.Drawing.Size(220, 46);
            this.btnBooks.Text = "Books";
            this.btnBooks.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.TabIndex = 8;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnStudents.Location = new System.Drawing.Point(0, 206);
            this.btnStudents.Size = new System.Drawing.Size(220, 46);
            this.btnStudents.Text = "Members";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.TabIndex = 9;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.FlatAppearance.BorderSize = 0;
            this.btnIssue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnIssue.Location = new System.Drawing.Point(0, 254);
            this.btnIssue.Size = new System.Drawing.Size(220, 46);
            this.btnIssue.Text = "Issue && return";
            this.btnIssue.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.TabIndex = 10;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnFines
            // 
            this.btnFines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnFines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFines.FlatAppearance.BorderSize = 0;
            this.btnFines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnFines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFines.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnFines.Location = new System.Drawing.Point(0, 302);
            this.btnFines.Size = new System.Drawing.Size(220, 46);
            this.btnFines.Text = "Fines";
            this.btnFines.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnFines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFines.UseVisualStyleBackColor = false;
            this.btnFines.Name = "btnFines";
            this.btnFines.TabIndex = 11;
            this.btnFines.Click += new System.EventHandler(this.btnFines_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnReports.Location = new System.Drawing.Point(0, 350);
            this.btnReports.Size = new System.Drawing.Size(220, 46);
            this.btnReports.Text = "Reports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Name = "btnReports";
            this.btnReports.TabIndex = 12;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLibrarians
            // 
            this.btnLibrarians.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnLibrarians.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibrarians.FlatAppearance.BorderSize = 0;
            this.btnLibrarians.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnLibrarians.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibrarians.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibrarians.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnLibrarians.Location = new System.Drawing.Point(0, 398);
            this.btnLibrarians.Size = new System.Drawing.Size(220, 46);
            this.btnLibrarians.Text = "Librarians";
            this.btnLibrarians.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnLibrarians.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibrarians.UseVisualStyleBackColor = false;
            this.btnLibrarians.Name = "btnLibrarians";
            this.btnLibrarians.TabIndex = 13;
            this.btnLibrarians.Click += new System.EventHandler(this.btnLibrarians_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 740);
            this.btnLogout.Size = new System.Drawing.Size(220, 46);
            this.btnLogout.Text = "Sign out";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblLogoSub;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnFines;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLibrarians;
        private System.Windows.Forms.Button btnLogout;
    }
}
