using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            await Db.EnsureDatabaseSchemaAsync();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ForgotPasswordForm form = new ForgotPasswordForm(txtUsername.Text.Trim()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    txtPassword.Clear();
                    if (!string.IsNullOrEmpty(form.ResetUsername))
                        txtUsername.Text = form.ResetUsername;
                    txtPassword.Focus();
                }
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your username and password.", "Sign in",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            try
            {
                // Retrieve user name and role from database
                DataTable dt = await Db.GetTableAsync(
                    "SELECT Full_Name, ISNULL(Role, 'Admin') AS Role FROM logintab WHERE Username = @username AND Password_Hash = @hash",
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@hash", HashPassword(txtPassword.Text)));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Wrong username or password.", "Sign in",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                string fullName = dt.Rows[0]["Full_Name"].ToString();
                string role = dt.Rows[0]["Role"].ToString();

                CurrentUser.Username = txtUsername.Text.Trim();
                CurrentUser.FullName = fullName;
                CurrentUser.Role = role;

                // when the main window closes: sign out -> back to login, otherwise exit
                MainForm main = new MainForm(fullName, role);
                Hide();
                main.ShowDialog();

                if (main.SignedOut)
                {
                    txtPassword.Clear();
                    CurrentUser.Reset();
                    Show();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
            finally
            {
                if (!IsDisposed) btnLogin.Enabled = true;
            }
        }

        // Unicode here matches HASHBYTES on N'...' text in schema.sql
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.Unicode.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }
    }
}
