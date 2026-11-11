using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void DashboardPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvOverdue);

            try
            {
                // all queries run at the same time, then we wait for all of them
                Task<object> books = Db.GetValueAsync("SELECT COUNT(*) FROM books");
                Task<object> students = Db.GetValueAsync("SELECT COUNT(*) FROM students");
                Task<object> onLoan = Db.GetValueAsync("SELECT COUNT(*) FROM issue WHERE Return_Date IS NULL");
                Task<object> overdue = Db.GetValueAsync(
                    "SELECT COUNT(*) FROM issue WHERE Return_Date IS NULL AND Due_Date < CAST(GETDATE() AS date)");
                Task<object> unpaidFines = Db.GetValueAsync("SELECT ISNULL(SUM(Amount), 0) FROM fine WHERE Paid = 0");
                Task<DataTable> perMonth = Db.GetTableAsync(
                    @"SELECT LEFT(DATENAME(MONTH, Issue_Date), 3) AS Month, COUNT(*) AS Loans
                      FROM issue
                      WHERE Issue_Date >= DATEADD(MONTH, -6, GETDATE())
                      GROUP BY YEAR(Issue_Date), MONTH(Issue_Date), DATENAME(MONTH, Issue_Date)
                      ORDER BY YEAR(Issue_Date), MONTH(Issue_Date)");
                Task<DataTable> overdueList = Db.GetTableAsync(
                    @"SELECT s.Student_Name AS Member, b.Book_Name AS Book,
                             DATEDIFF(DAY, i.Due_Date, GETDATE()) AS Days_Late
                      FROM issue i
                      JOIN students s ON s.StudentID = i.StudentID
                      JOIN books b ON b.BookID = i.BookID
                      WHERE i.Return_Date IS NULL AND i.Due_Date < CAST(GETDATE() AS date)
                      ORDER BY Days_Late DESC");

                await Task.WhenAll(books, students, onLoan, overdue, unpaidFines, perMonth, overdueList);

                lblBooksValue.Text = books.Result.ToString();
                lblStudentsValue.Text = students.Result.ToString();
                lblOnLoanValue.Text = onLoan.Result.ToString();
                lblOverdueValue.Text = overdue.Result.ToString();
                lblFinesValue.Text = Convert.ToDecimal(unpaidFines.Result).ToString("N0") + " EGP";
                dgvOverdue.DataSource = overdueList.Result;

                // one bar per month: the month name under it, the number of loans as its height
                DataTable months = perMonth.Result;
                string[] labels = new string[months.Rows.Count];
                int[] values = new int[months.Rows.Count];
                for (int i = 0; i < months.Rows.Count; i++)
                {
                    labels[i] = months.Rows[i]["Month"].ToString();
                    values[i] = Convert.ToInt32(months.Rows[i]["Loans"]);
                }
                chartLoans.SetData(labels, values);
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }
    }
}
