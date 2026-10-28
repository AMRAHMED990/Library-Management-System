using System;
using System.Data;
using System.Data.SqlClient;
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
                DateTime firstMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-5);

                // all queries run at the same time, then we wait for all of them
                Task<object> books = Db.GetValueAsync("SELECT COUNT(*) FROM books");
                Task<object> students = Db.GetValueAsync("SELECT COUNT(*) FROM students");
                Task<object> onLoan = Db.GetValueAsync("SELECT COUNT(*) FROM issue WHERE Return_Date IS NULL");
                Task<object> overdue = Db.GetValueAsync(
                    "SELECT COUNT(*) FROM issue WHERE Return_Date IS NULL AND Due_Date < CAST(GETDATE() AS date)");
                Task<object> unpaidFines = Db.GetValueAsync("SELECT ISNULL(SUM(Amount), 0) FROM fine WHERE Paid = 0");
                Task<DataTable> perMonth = Db.GetTableAsync(
                    @"SELECT YEAR(Issue_Date) AS Y, MONTH(Issue_Date) AS M, COUNT(*) AS Total
                      FROM issue WHERE Issue_Date >= @from
                      GROUP BY YEAR(Issue_Date), MONTH(Issue_Date)",
                    new SqlParameter("@from", firstMonth));
                Task<DataTable> overdueList = Db.GetTableAsync(
                    @"SELECT s.Student_Name AS Student, b.Book_Name AS Book,
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

                // last 6 months, 0 if a month had no loans
                string[] labels = new string[6];
                int[] values = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    DateTime month = firstMonth.AddMonths(i);
                    labels[i] = month.ToString("MMM");
                    DataRow[] rows = perMonth.Result.Select("Y = " + month.Year + " AND M = " + month.Month);
                    values[i] = rows.Length > 0 ? Convert.ToInt32(rows[0]["Total"]) : 0;
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
