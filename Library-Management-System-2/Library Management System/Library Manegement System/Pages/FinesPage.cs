using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class FinesPage : UserControl
    {
        private int selectedFineId = 0;   // 0 = nothing selected
        private bool selectedIsPaid;

        public FinesPage()
        {
            InitializeComponent();
        }

        private async void FinesPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvFines);
            btnDelete.Visible = CurrentUser.IsAdmin;
            cmbFilter.SelectedIndex = 0;   // this loads the grid too
            await LoadLoansComboAsync();
        }

        private async Task LoadFinesAsync()
        {
            try
            {
                string sql = @"SELECT * FROM (
                                   SELECT f.FineID, f.IssueID, s.Student_Name AS Member, b.Book_Name AS Book,
                                          f.Amount, f.Fine_Date,
                                          CASE WHEN f.Paid = 1 THEN 'Paid' ELSE 'Unpaid' END AS Status
                                   FROM fine f
                                   JOIN issue i ON i.IssueID = f.IssueID
                                   JOIN students s ON s.StudentID = i.StudentID
                                   JOIN books b ON b.BookID = i.BookID
                               ) AS fines
                               WHERE @status = 'All' OR Status = @status
                               ORDER BY FineID DESC";
                dgvFines.DataSource = await Db.GetTableAsync(sql, new SqlParameter("@status", cmbFilter.Text));

                object total = await Db.GetValueAsync("SELECT ISNULL(SUM(Amount), 0) FROM fine WHERE Paid = 0");
                lblTotal.Text = "Unpaid total: " + Convert.ToDecimal(total).ToString("N2") + " EGP";
                ClearSelection();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async Task LoadLoansComboAsync()
        {
            try
            {
                cmbLoan.DisplayMember = "Loan";
                cmbLoan.ValueMember = "IssueID";
                cmbLoan.DataSource = await Db.GetTableAsync(
                    @"SELECT i.IssueID, '#' + CAST(i.IssueID AS varchar(10)) + ' - ' + s.Student_Name + ' - ' + b.Book_Name AS Loan
                      FROM issue i
                      JOIN students s ON s.StudentID = i.StudentID
                      JOIN books b ON b.BookID = i.BookID
                      ORDER BY i.IssueID DESC");
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadFinesAsync();
        }

        private void dgvFines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvFines.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
                e.CellStyle.ForeColor = Theme.StatusColor(e.Value.ToString());
        }

        private void dgvFines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvFines.Rows[e.RowIndex];

            selectedFineId = Convert.ToInt32(row.Cells["FineID"].Value);
            selectedIsPaid = row.Cells["Status"].Value.ToString() == "Paid";
            lblSelectedFine.Text = "Fine #" + selectedFineId + ": " + Convert.ToDecimal(row.Cells["Amount"].Value).ToString("N2") + " EGP"
                + "\n" + row.Cells["Member"].Value + " - " + row.Cells["Book"].Value
                + "\n" + (selectedIsPaid ? "Paid" : "Not paid yet");
            btnPay.Enabled = !selectedIsPaid;
            btnDelete.Enabled = CurrentUser.IsAdmin;
        }

        private void ClearSelection()
        {
            selectedFineId = 0;
            lblSelectedFine.Text = "Click a fine in the list.";
            btnPay.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (selectedFineId == 0 || selectedIsPaid) return;
            try
            {
                await Db.ExecuteAsync("UPDATE fine SET Paid = 1, Paid_Date = @today WHERE FineID = @id",
                    new SqlParameter("@today", DateTime.Today),
                    new SqlParameter("@id", selectedFineId));
                await LoadFinesAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Only administrators can delete fines.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedFineId == 0) return;
            if (MessageBox.Show("Delete this fine?", "Fines", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                await Db.ExecuteAsync("DELETE FROM fine WHERE FineID = @id", new SqlParameter("@id", selectedFineId));
                await LoadFinesAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnAddFine_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            decimal amount;
            if (cmbLoan.SelectedValue == null)
            {
                errorProvider.SetError(cmbLoan, "Choose a loan.");
                return;
            }
            if (!Validation.IsAmount(txtAmount.Text, out amount))
            {
                errorProvider.SetError(txtAmount, "Enter a positive amount, like 150 or 75.50.");
                return;
            }

            try
            {
                await Db.ExecuteAsync(
                    "INSERT INTO fine (IssueID, Amount, Paid, Fine_Date) VALUES (@issue, @amount, 0, @today)",
                    new SqlParameter("@issue", (int)cmbLoan.SelectedValue),
                    new SqlParameter("@amount", amount),
                    new SqlParameter("@today", DateTime.Today));
                txtAmount.Clear();
                MessageBox.Show("Fine added.", "Fines", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadFinesAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }
    }
}
