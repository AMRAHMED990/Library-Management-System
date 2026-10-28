using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class StudentsPage : UserControl
    {
        private int selectedStudentId = 0;   // 0 = nothing selected

        public StudentsPage()
        {
            InitializeComponent();
        }

        private async void StudentsPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvStudents);
            cmbGender.SelectedIndex = 0;
            await LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                string sql = @"SELECT StudentID, Student_Name, Gender, Email, Phone_Number, Address
                               FROM students
                               WHERE Student_Name LIKE @search OR Email LIKE @search OR Phone_Number LIKE @search
                               ORDER BY Student_Name";
                dgvStudents.DataSource = await Db.GetTableAsync(sql,
                    new SqlParameter("@search", "%" + txtSearch.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadStudentsAsync();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

            selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            txtName.Text = row.Cells["Student_Name"].Value.ToString();
            cmbGender.SelectedItem = row.Cells["Gender"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtPhone.Text = row.Cells["Phone_Number"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            lblDetailsTitle.Text = "Edit student #" + selectedStudentId;
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
            if (txtAddress.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtAddress, "Address is required.");
                valid = false;
            }
            return valid;
        }

        private SqlParameter[] StudentParameters()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@name", txtName.Text.Trim()),
                new SqlParameter("@gender", cmbGender.Text),
                new SqlParameter("@email", txtEmail.Text.Trim()),
                new SqlParameter("@phone", txtPhone.Text.Trim()),
                new SqlParameter("@address", txtAddress.Text.Trim()),
                new SqlParameter("@id", selectedStudentId)
            };
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            try
            {
                await Db.ExecuteAsync(
                    @"INSERT INTO students (Student_Name, Gender, Email, Phone_Number, Address)
                      VALUES (@name, @gender, @email, @phone, @address)",
                    StudentParameters());
                MessageBox.Show("Student added.", "Students", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Click a student in the list first.", "Students");
                return;
            }
            if (!ValidateForm()) return;
            try
            {
                await Db.ExecuteAsync(
                    @"UPDATE students SET Student_Name = @name, Gender = @gender, Email = @email,
                             Phone_Number = @phone, Address = @address
                      WHERE StudentID = @id",
                    StudentParameters());
                MessageBox.Show("Student updated.", "Students", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Click a student in the list first.", "Students");
                return;
            }
            if (MessageBox.Show("Delete this student?", "Students", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                await Db.ExecuteAsync("DELETE FROM students WHERE StudentID = @id", new SqlParameter("@id", selectedStudentId));
                ClearForm();
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);   // fails if the student has loans
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedStudentId = 0;
            txtName.Clear();
            cmbGender.SelectedIndex = 0;
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            lblDetailsTitle.Text = "New student";
            errorProvider.Clear();
        }
    }
}
