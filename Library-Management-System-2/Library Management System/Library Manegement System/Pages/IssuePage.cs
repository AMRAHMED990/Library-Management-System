using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class IssuePage : UserControl
    {
        private int selectedIssueId = 0;   // 0 = nothing selected
        private DateTime selectedDueDate;
        private bool selectedIsReturned;

        public IssuePage()
        {
            InitializeComponent();
        }

        private async void IssuePage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvLoans);
            dtpIssueDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(LibraryRules.LoanDays);
            cmbFilter.SelectedIndex = 0;   // this loads the grid too
            await LoadComboBoxesAsync();
        }

        private async Task LoadComboBoxesAsync()
        {
            try
            {
                cmbStudent.DisplayMember = "Student_Name";   // what we show
                cmbStudent.ValueMember = "StudentID";   // what we save
                cmbStudent.DataSource = await Db.GetTableAsync(
                    "SELECT StudentID, Student_Name FROM students ORDER BY Student_Name");

                cmbBook.DisplayMember = "Book_Name";
                cmbBook.ValueMember = "BookID";
                cmbBook.DataSource = await Db.GetTableAsync(
                    @"SELECT BookID, Book_Name FROM books
                      WHERE Copies > (SELECT COUNT(*) FROM issue WHERE issue.BookID = books.BookID AND Return_Date IS NULL)
                      ORDER BY Book_Name");
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async Task LoadLoansAsync()
        {
            try
            {
                string sql = @"SELECT * FROM (
                                   SELECT i.IssueID, s.Student_Name AS Member, b.Book_Name AS Book,
                                          i.Issue_Date, i.Due_Date, i.Return_Date,
                                          CASE WHEN i.Return_Date IS NOT NULL THEN 'Returned'
                                               WHEN i.Due_Date < CAST(GETDATE() AS date) THEN 'Overdue'
                                               ELSE 'On loan' END AS Status
                                   FROM issue i
                                   JOIN students s ON s.StudentID = i.StudentID
                                   JOIN books b ON b.BookID = i.BookID
                               ) AS loans
                               WHERE (Member LIKE @search OR Book LIKE @search)
                                 AND (@status = 'All' OR Status = @status)
                               ORDER BY IssueID DESC";
                dgvLoans.DataSource = await Db.GetTableAsync(sql,
                    new SqlParameter("@search", "%" + txtSearch.Text.Trim() + "%"),
                    new SqlParameter("@status", cmbFilter.Text));
                ClearSelection();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadLoansAsync();
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadLoansAsync();
        }

        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            dtpDueDate.Value = dtpIssueDate.Value.AddDays(LibraryRules.LoanDays);
        }

        private void dgvLoans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoans.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
                e.CellStyle.ForeColor = Theme.StatusColor(e.Value.ToString());
        }

        private async void btnIssue_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null || cmbBook.SelectedValue == null)
            {
                MessageBox.Show("Choose a member and a book.", "Issue book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpDueDate.Value.Date < dtpIssueDate.Value.Date)
            {
                MessageBox.Show("The due date can't be before the issue date.", "Issue book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = (int)cmbStudent.SelectedValue;
            int bookId = (int)cmbBook.SelectedValue;
            try
            {
                // max 3 books per member at a time
                int booksOnLoan = Convert.ToInt32(await Db.GetValueAsync(
                    "SELECT COUNT(*) FROM issue WHERE StudentID = @student AND Return_Date IS NULL",
                    new SqlParameter("@student", studentId)));
                if (booksOnLoan >= LibraryRules.MaxBooksPerStudent)
                {
                    MessageBox.Show("This member already has " + booksOnLoan + " books. The limit is "
                        + LibraryRules.MaxBooksPerStudent + ".", "Issue book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await Db.ExecuteAsync(
                    "INSERT INTO issue (StudentID, BookID, Issue_Date, Due_Date) VALUES (@student, @book, @issueDate, @dueDate)",
                    new SqlParameter("@student", studentId),
                    new SqlParameter("@book", bookId),
                    new SqlParameter("@issueDate", dtpIssueDate.Value.Date),
                    new SqlParameter("@dueDate", dtpDueDate.Value.Date));

                MessageBox.Show("Book issued. It is due back on " + dtpDueDate.Value.ToString("dd MMM yyyy") + ".",
                    "Issue book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadComboBoxesAsync();   // one less copy on the shelf now
                await LoadLoansAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLoans.Rows[e.RowIndex];

            selectedIssueId = Convert.ToInt32(row.Cells["IssueID"].Value);
            selectedDueDate = Convert.ToDateTime(row.Cells["Due_Date"].Value);
            selectedIsReturned = row.Cells["Return_Date"].Value != DBNull.Value;

            lblSelectedLoan.Text = "Loan #" + selectedIssueId + ": " + row.Cells["Book"].Value
                + "\nBorrowed by " + row.Cells["Member"].Value
                + "\nDue " + selectedDueDate.ToString("dd MMM yyyy")
                + (selectedIsReturned ? " (already returned)" : "");
            btnReturn.Enabled = !selectedIsReturned;
        }

        private void ClearSelection()
        {
            selectedIssueId = 0;
            lblSelectedLoan.Text = "Click a loan in the list to return it.";
            btnReturn.Enabled = false;
        }

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedIssueId == 0 || selectedIsReturned) return;

            // fine = days late x 5 EGP
            int daysLate = (DateTime.Today - selectedDueDate.Date).Days;
            decimal fine = daysLate > 0 ? daysLate * LibraryRules.FinePerDay : 0;

            try
            {
                await Db.ExecuteAsync("UPDATE issue SET Return_Date = @today WHERE IssueID = @id",
                    new SqlParameter("@today", DateTime.Today),
                    new SqlParameter("@id", selectedIssueId));

                if (fine > 0)
                {
                    await Db.ExecuteAsync(
                        "INSERT INTO fine (IssueID, Amount, Paid, Fine_Date) VALUES (@id, @amount, 0, @today)",
                        new SqlParameter("@id", selectedIssueId),
                        new SqlParameter("@amount", fine),
                        new SqlParameter("@today", DateTime.Today));
                    MessageBox.Show("Book returned " + daysLate + " days late. A fine of " + fine.ToString("N2")
                        + " EGP was added.", "Return book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Book returned on time.", "Return book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadComboBoxesAsync();
                await LoadLoansAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }
    }
}
