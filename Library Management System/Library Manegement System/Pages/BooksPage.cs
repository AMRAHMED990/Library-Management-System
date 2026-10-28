using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class BooksPage : UserControl
    {
        private int selectedBookId = 0;   // 0 = nothing selected

        public BooksPage()
        {
            InitializeComponent();
        }

        private async void BooksPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvBooks);
            cmbCategory.SelectedIndex = 0;
            await LoadBooksAsync();
        }

        private async Task LoadBooksAsync()
        {
            try
            {
                string sql = @"SELECT BookID, ISBN, Book_Name, Author, Publisher, Category, Copies,
                                      Copies - (SELECT COUNT(*) FROM issue
                                                WHERE issue.BookID = books.BookID AND Return_Date IS NULL) AS Available
                               FROM books
                               WHERE Book_Name LIKE @search OR Author LIKE @search OR ISBN LIKE @search
                               ORDER BY Book_Name";
                dgvBooks.DataSource = await Db.GetTableAsync(sql,
                    new SqlParameter("@search", "%" + txtSearch.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadBooksAsync();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

            selectedBookId = Convert.ToInt32(row.Cells["BookID"].Value);
            txtIsbn.Text = row.Cells["ISBN"].Value.ToString();
            txtTitle.Text = row.Cells["Book_Name"].Value.ToString();
            txtAuthor.Text = row.Cells["Author"].Value.ToString();
            txtPublisher.Text = row.Cells["Publisher"].Value.ToString();
            cmbCategory.SelectedItem = row.Cells["Category"].Value.ToString();
            numCopies.Value = Convert.ToInt32(row.Cells["Copies"].Value);
            lblDetailsTitle.Text = "Edit book #" + selectedBookId;
            errorProvider.Clear();
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool valid = true;

            if (txtIsbn.Text.Trim() != "" && !Validation.IsIsbn(txtIsbn.Text))
            {
                errorProvider.SetError(txtIsbn, "ISBN must be 10 or 13 digits.");
                valid = false;
            }
            if (txtTitle.Text.Trim() == "")
            {
                errorProvider.SetError(txtTitle, "Title is required.");
                valid = false;
            }
            if (txtAuthor.Text.Trim().Length < 2)
            {
                errorProvider.SetError(txtAuthor, "Author is required.");
                valid = false;
            }
            if (txtPublisher.Text.Trim().Length < 2)
            {
                errorProvider.SetError(txtPublisher, "Publisher is required.");
                valid = false;
            }
            return valid;
        }

        private SqlParameter[] BookParameters()
        {
            string isbn = Validation.CleanIsbn(txtIsbn.Text);
            return new SqlParameter[]
            {
                new SqlParameter("@isbn", isbn == "" ? (object)DBNull.Value : isbn),
                new SqlParameter("@name", txtTitle.Text.Trim()),
                new SqlParameter("@author", txtAuthor.Text.Trim()),
                new SqlParameter("@publisher", txtPublisher.Text.Trim()),
                new SqlParameter("@category", cmbCategory.Text),
                new SqlParameter("@copies", (int)numCopies.Value),
                new SqlParameter("@id", selectedBookId)
            };
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            try
            {
                await Db.ExecuteAsync(
                    @"INSERT INTO books (ISBN, Book_Name, Author, Publisher, Category, Copies)
                      VALUES (@isbn, @name, @author, @publisher, @category, @copies)",
                    BookParameters());
                MessageBox.Show("Book added.", "Books", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadBooksAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Click a book in the list first.", "Books");
                return;
            }
            if (!ValidateForm()) return;
            try
            {
                // copies can't go below what's already borrowed
                int onLoan = Convert.ToInt32(await Db.GetValueAsync(
                    "SELECT COUNT(*) FROM issue WHERE BookID = @id AND Return_Date IS NULL",
                    new SqlParameter("@id", selectedBookId)));
                if (numCopies.Value < onLoan)
                {
                    errorProvider.SetError(numCopies, onLoan + " copies are on loan, so copies can't be less than " + onLoan + ".");
                    return;
                }

                await Db.ExecuteAsync(
                    @"UPDATE books SET ISBN = @isbn, Book_Name = @name, Author = @author,
                             Publisher = @publisher, Category = @category, Copies = @copies
                      WHERE BookID = @id",
                    BookParameters());
                MessageBox.Show("Book updated.", "Books", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadBooksAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Click a book in the list first.", "Books");
                return;
            }
            if (MessageBox.Show("Delete this book?", "Books", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                await Db.ExecuteAsync("DELETE FROM books WHERE BookID = @id", new SqlParameter("@id", selectedBookId));
                ClearForm();
                await LoadBooksAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);   // fails if the book has loans
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedBookId = 0;
            txtIsbn.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            cmbCategory.SelectedIndex = 0;
            numCopies.Value = 1;
            lblDetailsTitle.Text = "New book";
            errorProvider.Clear();
        }

        private async void btnLookup_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!Validation.IsIsbn(txtIsbn.Text))
            {
                errorProvider.SetError(txtIsbn, "Type a 10 or 13 digit ISBN first.");
                return;
            }

            btnLookup.Enabled = false;
            btnLookup.Text = "Searching…";
            try
            {
                BookInfo book = await OpenLibrary.FindBookAsync(Validation.CleanIsbn(txtIsbn.Text));
                if (book == null)
                {
                    MessageBox.Show("No book was found for this ISBN. Please type the details yourself.", "Find online");
                    return;
                }
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtPublisher.Text = book.Publisher;
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
            finally
            {
                btnLookup.Enabled = true;
                btnLookup.Text = "Find online";
            }
        }
    }
}
