namespace Library_Manegement_System
{
    partial class FinesPage
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
            this.components = new System.ComponentModel.Container();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvFines = new System.Windows.Forms.DataGridView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblSelectedTitle = new System.Windows.Forms.Label();
            this.lblSelectedFine = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.lblAddNote = new System.Windows.Forms.Label();
            this.lblLoan = new System.Windows.Forms.Label();
            this.cmbLoan = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddFine = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblFilter.Location = new System.Drawing.Point(0, 10);
            this.lblFilter.Text = "Show";
            this.lblFilter.AutoSize = true;
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.TabIndex = 0;
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(48, 4);
            this.cmbFilter.Size = new System.Drawing.Size(150, 31);
            this.cmbFilter.Items.AddRange(new object[] {
            "All",
            "Unpaid",
            "Paid"});
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.TabIndex = 1;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(56)))), ((int)(((byte)(75)))));
            this.lblTotal.Location = new System.Drawing.Point(220, 9);
            this.lblTotal.Text = "Unpaid total: 0 EGP";
            this.lblTotal.AutoSize = true;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 2;
            // 
            // dgvFines
            // 
            this.dgvFines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFines.Location = new System.Drawing.Point(0, 44);
            this.dgvFines.Size = new System.Drawing.Size(630, 576);
            this.dgvFines.Name = "dgvFines";
            this.dgvFines.TabIndex = 3;
            this.dgvFines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFines_CellClick);
            this.dgvFines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFines_CellFormatting);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblSelectedTitle);
            this.pnlDetails.Controls.Add(this.lblSelectedFine);
            this.pnlDetails.Controls.Add(this.btnPay);
            this.pnlDetails.Controls.Add(this.btnDelete);
            this.pnlDetails.Controls.Add(this.pnlLine);
            this.pnlDetails.Controls.Add(this.lblAddTitle);
            this.pnlDetails.Controls.Add(this.lblAddNote);
            this.pnlDetails.Controls.Add(this.lblLoan);
            this.pnlDetails.Controls.Add(this.cmbLoan);
            this.pnlDetails.Controls.Add(this.lblAmount);
            this.pnlDetails.Controls.Add(this.txtAmount);
            this.pnlDetails.Controls.Add(this.btnAddFine);
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.Location = new System.Drawing.Point(650, 0);
            this.pnlDetails.Size = new System.Drawing.Size(350, 620);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.TabIndex = 4;
            // 
            // lblSelectedTitle
            // 
            this.lblSelectedTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblSelectedTitle.Location = new System.Drawing.Point(20, 16);
            this.lblSelectedTitle.Text = "Selected fine";
            this.lblSelectedTitle.AutoSize = true;
            this.lblSelectedTitle.Name = "lblSelectedTitle";
            this.lblSelectedTitle.TabIndex = 5;
            // 
            // lblSelectedFine
            // 
            this.lblSelectedFine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblSelectedFine.Location = new System.Drawing.Point(20, 54);
            this.lblSelectedFine.Text = "Click a fine in the list.";
            this.lblSelectedFine.AutoSize = false;
            this.lblSelectedFine.Size = new System.Drawing.Size(300, 70);
            this.lblSelectedFine.Name = "lblSelectedFine";
            this.lblSelectedFine.TabIndex = 6;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(59)))), ((int)(((byte)(51)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(84)))), ((int)(((byte)(72)))));
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(20, 130);
            this.btnPay.Size = new System.Drawing.Size(300, 38);
            this.btnPay.Text = "Mark as paid";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Name = "btnPay";
            this.btnPay.TabIndex = 7;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(56)))), ((int)(((byte)(75)))));
            this.btnDelete.FlatAppearance.BorderSize = 1;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(56)))), ((int)(((byte)(75)))));
            this.btnDelete.Location = new System.Drawing.Point(20, 176);
            this.btnDelete.Size = new System.Drawing.Size(300, 38);
            this.btnDelete.Text = "Delete fine";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.pnlLine.Location = new System.Drawing.Point(20, 236);
            this.pnlLine.Size = new System.Drawing.Size(300, 1);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.TabIndex = 9;
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.lblAddTitle.Location = new System.Drawing.Point(20, 254);
            this.lblAddTitle.Text = "Add a fine";
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.TabIndex = 10;
            // 
            // lblAddNote
            // 
            this.lblAddNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblAddNote.Location = new System.Drawing.Point(20, 286);
            this.lblAddNote.Text = "For a lost or damaged book. Late fines are added automatically on return.";
            this.lblAddNote.AutoSize = false;
            this.lblAddNote.Size = new System.Drawing.Size(300, 36);
            this.lblAddNote.Name = "lblAddNote";
            this.lblAddNote.TabIndex = 11;
            // 
            // lblLoan
            // 
            this.lblLoan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblLoan.Location = new System.Drawing.Point(20, 328);
            this.lblLoan.Text = "Loan";
            this.lblLoan.AutoSize = true;
            this.lblLoan.Name = "lblLoan";
            this.lblLoan.TabIndex = 12;
            // 
            // cmbLoan
            // 
            this.cmbLoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoan.FormattingEnabled = true;
            this.cmbLoan.Location = new System.Drawing.Point(20, 349);
            this.cmbLoan.Size = new System.Drawing.Size(300, 31);
            this.cmbLoan.Name = "cmbLoan";
            this.cmbLoan.TabIndex = 13;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(111)))));
            this.lblAmount.Location = new System.Drawing.Point(20, 386);
            this.lblAmount.Text = "Amount (EGP)";
            this.lblAmount.AutoSize = true;
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.TabIndex = 14;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(20, 407);
            this.txtAmount.Size = new System.Drawing.Size(145, 30);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.TabIndex = 15;
            // 
            // btnAddFine
            // 
            this.btnAddFine.BackColor = System.Drawing.Color.White;
            this.btnAddFine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(224)))), ((int)(((byte)(220)))));
            this.btnAddFine.FlatAppearance.BorderSize = 1;
            this.btnAddFine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.btnAddFine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFine.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(33)))));
            this.btnAddFine.Location = new System.Drawing.Point(20, 454);
            this.btnAddFine.Size = new System.Drawing.Size(300, 38);
            this.btnAddFine.Text = "Add fine";
            this.btnAddFine.UseVisualStyleBackColor = false;
            this.btnAddFine.Name = "btnAddFine";
            this.btnAddFine.TabIndex = 16;
            this.btnAddFine.Click += new System.EventHandler(this.btnAddFine_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FinesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvFines);
            this.Controls.Add(this.pnlDetails);
            this.Name = "FinesPage";
            this.Size = new System.Drawing.Size(1000, 620);
            this.Load += new System.EventHandler(this.FinesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlLine.ResumeLayout(false);
            this.pnlLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvFines;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblSelectedTitle;
        private System.Windows.Forms.Label lblSelectedFine;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.Label lblAddNote;
        private System.Windows.Forms.Label lblLoan;
        private System.Windows.Forms.ComboBox cmbLoan;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAddFine;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
