using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class LibrariansPage : UserControl
    {
        private int selectedLibrarianId = 0;   // 0 = nothing selected

        public LibrariansPage()
        {
            InitializeComponent();
        }

        private async void LibrariansPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvLibrarians);
            await LoadLibrariansAsync();
        }

        private async Task LoadLibrariansAsync()
        {
            try
            {
                string sql = @"SELECT LibrarianID, Name, Email, Phone_Number
                               FROM librarians
                               WHERE Name LIKE @search OR Email LIKE @search OR Phone_Number LIKE @search
                               ORDER BY Name";
                dgvLibrarians.DataSource = await Db.GetTableAsync(sql,
                    new SqlParameter("@search", "%" + txtSearch.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadLibrariansAsync();
        }

        private void dgvLibrarians_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLibrarians.Rows[e.RowIndex];

            selectedLibrarianId = Convert.ToInt32(row.Cells["LibrarianID"].Value);
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtPhone.Text = row.Cells["Phone_Number"].Value.ToString();
            lblDetailsTitle.Text = "Edit librarian #" + selectedLibrarianId;
            errorProvider.Clear();
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool valid = true;

            if (!Validation.IsName(txtName.Text))
            {
                errorProvider.SetError(txtName, "Enter a name using letters only (at least 3).");
                valid = false;
            }
            if (!Validation.IsEmail(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Enter a valid email, like name@example.com.");
                valid = false;
            }
            if (!Validation.IsPhone(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Enter an 11-digit number starting with 010, 011, 012 or 015.");
                valid = false;
            }
            return valid;
        }

        private SqlParameter[] LibrarianParameters()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@name", txtName.Text.Trim()),
                new SqlParameter("@email", txtEmail.Text.Trim()),
                new SqlParameter("@phone", txtPhone.Text.Trim()),
                new SqlParameter("@id", selectedLibrarianId)
            };
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            try
            {
                await Db.ExecuteAsync(
                    "INSERT INTO librarians (Name, Email, Phone_Number) VALUES (@name, @email, @phone)",
                    LibrarianParameters());
                MessageBox.Show("Librarian added.", "Librarians", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadLibrariansAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedLibrarianId == 0)
            {
                MessageBox.Show("Click a librarian in the list first.", "Librarians");
                return;
            }
            if (!ValidateForm()) return;
            try
            {
                await Db.ExecuteAsync(
                    "UPDATE librarians SET Name = @name, Email = @email, Phone_Number = @phone WHERE LibrarianID = @id",
                    LibrarianParameters());
                MessageBox.Show("Librarian updated.", "Librarians", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadLibrariansAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedLibrarianId == 0)
            {
                MessageBox.Show("Click a librarian in the list first.", "Librarians");
                return;
            }
            if (MessageBox.Show("Delete this librarian?", "Librarians", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                await Db.ExecuteAsync("DELETE FROM librarians WHERE LibrarianID = @id", new SqlParameter("@id", selectedLibrarianId));
                ClearForm();
                await LoadLibrariansAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedLibrarianId = 0;
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            lblDetailsTitle.Text = "New librarian";
            errorProvider.Clear();
        }
    }
}
