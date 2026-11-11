using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class ForgotPasswordForm : Form
    {
        public string ResetUsername { get; private set; }

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        public ForgotPasswordForm(string initialUsername) : this()
        {
            if (!string.IsNullOrEmpty(initialUsername))
            {
                txtUsername.Text = initialUsername;
                txtNewPassword.Focus();
            }
        }

        private void chkShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPasswords.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPasswords.Checked;
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            string username = txtUsername.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                errorProvider.SetError(txtUsername, "Please enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPass) || newPass.Length < 4)
            {
                errorProvider.SetError(txtNewPassword, "Password must be at least 4 characters long.");
                txtNewPassword.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
                txtConfirmPassword.Focus();
                return;
            }

            btnReset.Enabled = false;
            try
            {
                // Verify user exists in logintab
                object userExists = await Db.GetValueAsync(
                    "SELECT UserID FROM logintab WHERE Username = @username",
                    new SqlParameter("@username", username));

                if (userExists == null)
                {
                    errorProvider.SetError(txtUsername, "Username not found in system.");
                    txtUsername.Focus();
                    return;
                }

                // Update password hash
                string hash = LoginForm.HashPassword(newPass);
                await Db.ExecuteAsync(
                    "UPDATE logintab SET Password_Hash = @hash WHERE Username = @username",
                    new SqlParameter("@hash", hash),
                    new SqlParameter("@username", username));

                ResetUsername = username;
                MessageBox.Show(
                    "Password has been reset successfully!\nYou can now sign in with your new password.",
                    "Password Reset",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
            finally
            {
                if (!IsDisposed) btnReset.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
