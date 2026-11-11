using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class MainForm : Form
    {
        public bool SignedOut { get; private set; }

        public MainForm(string userName) : this(userName, CurrentUser.Role)
        {
        }

        public MainForm(string userName, string role)
        {
            InitializeComponent();
            CurrentUser.FullName = userName;
            CurrentUser.Role = role ?? "Admin";

            string roleBadge = CurrentUser.IsSubadmin ? "Subadmin" : "Admin";
            lblUser.Text = "Signed in as " + userName + " (" + roleBadge + ")  ·  " + DateTime.Today.ToString("dd MMM yyyy");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configure role privileges
            if (CurrentUser.IsSubadmin)
            {
                btnLibrarians.Visible = false;
            }

            btnStudents.Text = "Members";
            ShowPage(new DashboardPage(), "Dashboard", btnDashboard);
        }

        private void ShowPage(UserControl page, string title, Button menuButton)
        {
            // close the old page first
            while (pnlContent.Controls.Count > 0)
                pnlContent.Controls[0].Dispose();

            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
            lblPageTitle.Text = title;

            foreach (Control control in pnlSidebar.Controls)
            {
                Button button = control as Button;
                if (button != null)
                    button.BackColor = button == menuButton ? Theme.LampActive : Theme.Lamp;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e) { ShowPage(new DashboardPage(), "Dashboard", btnDashboard); }
        private void btnBooks_Click(object sender, EventArgs e) { ShowPage(new BooksPage(), "Books", btnBooks); }
        private void btnStudents_Click(object sender, EventArgs e) { ShowPage(new StudentsPage(), "Members", btnStudents); }
        private void btnIssue_Click(object sender, EventArgs e) { ShowPage(new IssuePage(), "Issue & return", btnIssue); }
        private void btnFines_Click(object sender, EventArgs e) { ShowPage(new FinesPage(), "Fines", btnFines); }
        private void btnReports_Click(object sender, EventArgs e) { ShowPage(new ReportsPage(), "Reports", btnReports); }

        private void btnLibrarians_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Administrator privileges are required to manage staff accounts.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowPage(new LibrariansPage(), "Librarians", btnLibrarians);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SignedOut = true;
            Close();
        }
    }
}
