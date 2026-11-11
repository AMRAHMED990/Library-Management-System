namespace Library_Manegement_System
{
    partial class ReportsPage
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
            this.lblReport = new System.Windows.Forms.Label();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReport
            // 
            this.lblReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblReport.Location = new System.Drawing.Point(0, 10);
            this.lblReport.Text = "Report";
            this.lblReport.AutoSize = true;
            this.lblReport.Name = "lblReport";
            this.lblReport.TabIndex = 0;
            // 
            // cmbReport
            // 
            this.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(56, 4);
            this.cmbReport.Size = new System.Drawing.Size(230, 31);
            this.cmbReport.Items.AddRange(new object[] {
            "Overdue books",
            "Most borrowed books",
            "Fines by member"});
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblFrom.Location = new System.Drawing.Point(302, 10);
            this.lblFrom.Text = "From";
            this.lblFrom.AutoSize = true;
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd MMM yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(342, 4);
            this.dtpFrom.Size = new System.Drawing.Size(140, 30);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblTo.Location = new System.Drawing.Point(494, 10);
            this.lblTo.Text = "To";
            this.lblTo.AutoSize = true;
            this.lblTo.Name = "lblTo";
            this.lblTo.TabIndex = 4;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd MMM yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(518, 4);
            this.dtpTo.Size = new System.Drawing.Size(140, 30);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(672, 0);
            this.btnShow.Size = new System.Drawing.Size(100, 38);
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Name = "btnShow";
            this.btnShow.TabIndex = 6;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.btnExport.FlatAppearance.BorderSize = 1;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.btnExport.Location = new System.Drawing.Point(782, 0);
            this.btnExport.Size = new System.Drawing.Size(140, 38);
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.TabIndex = 7;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblSummary.Location = new System.Drawing.Point(0, 52);
            this.lblSummary.Text = "";
            this.lblSummary.AutoSize = true;
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.TabIndex = 8;
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReport.Location = new System.Drawing.Point(0, 84);
            this.dgvReport.Size = new System.Drawing.Size(1000, 536);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.TabIndex = 9;
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgvReport);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(1000, 620);
            this.Load += new System.EventHandler(this.ReportsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}
