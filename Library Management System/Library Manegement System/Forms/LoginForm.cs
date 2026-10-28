using System;
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
                // we only store a hash of the password, so we compare hashes
                object found = await Db.GetValueAsync(
                    "SELECT Full_Name FROM logintab WHERE Username = @username AND Password_Hash = @hash",
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@hash", HashPassword(txtPassword.Text)));

                if (found == null)
                {
                    MessageBox.Show("Wrong username or password.", "Sign in",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // when the main window closes: sign out -> back to login, otherwise exit
                MainForm main = new MainForm(found.ToString());
                Hide();
                main.ShowDialog();

                if (main.SignedOut)
                {
                    txtPassword.Clear();
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
        private static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.Unicode.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }
    }
}
