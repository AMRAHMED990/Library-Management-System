using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class ReportsPage : UserControl
    {
        private DataTable currentReport;

        public ReportsPage()
        {
            InitializeComponent();
        }

        private void ReportsPage_Load(object sender, EventArgs e)
        {
            Theme.StyleGrid(dgvReport);
            cmbReport.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddMonths(-6);
            dtpTo.Value = DateTime.Today;
            btnExport.Enabled = false;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("'From' must be before 'To'.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql;
            switch (cmbReport.SelectedIndex)
            {
                case 0:   // overdue books
                    sql = @"SELECT s.Student_Name AS Member, s.Phone_Number AS Phone, b.Book_Name AS Book, i.Due_Date,
                                   DATEDIFF(DAY, i.Due_Date, GETDATE()) AS Days_Late
                            FROM issue i
                            JOIN students s ON s.StudentID = i.StudentID
                            JOIN books b ON b.BookID = i.BookID
                            WHERE i.Return_Date IS NULL AND i.Due_Date < CAST(GETDATE() AS date)
                            ORDER BY Days_Late DESC";
                    break;
                case 1:   // most borrowed
                    sql = @"SELECT TOP 10 b.Book_Name AS Book, b.Author, COUNT(*) AS Times_Borrowed
                            FROM issue i
                            JOIN books b ON b.BookID = i.BookID
                            WHERE i.Issue_Date BETWEEN @from AND @to
                            GROUP BY b.Book_Name, b.Author
                            ORDER BY Times_Borrowed DESC";
                    break;
                default:   // fines by member
                    sql = @"SELECT s.Student_Name AS Member, COUNT(*) AS Fines,
                                   SUM(CASE WHEN f.Paid = 0 THEN f.Amount ELSE 0 END) AS Unpaid,
                                   SUM(CASE WHEN f.Paid = 1 THEN f.Amount ELSE 0 END) AS Paid
                            FROM fine f
                            JOIN issue i ON i.IssueID = f.IssueID
                            JOIN students s ON s.StudentID = i.StudentID
                            GROUP BY s.Student_Name
                            ORDER BY Unpaid DESC";
                    break;
            }

            try
            {
                currentReport = await Db.GetTableAsync(sql,
                    new SqlParameter("@from", dtpFrom.Value.Date),
                    new SqlParameter("@to", dtpTo.Value.Date));
                dgvReport.DataSource = currentReport;
                lblSummary.Text = cmbReport.Text + ": " + currentReport.Rows.Count + " rows";
                btnExport.Enabled = currentReport.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            string path;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV file (*.csv)|*.csv";
                dialog.FileName = cmbReport.Text + ".csv";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                path = dialog.FileName;
            }

            try
            {
                // write the file on a background thread so the window doesn't freeze
                DataTable table = currentReport;
                await Task.Run(() => WriteCsv(table, path));

                MessageBox.Show("Report saved to " + path, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorHelper.Show(ex);
            }
        }

        private static void WriteCsv(DataTable table, string path)
        {
            StringBuilder csv = new StringBuilder();

            for (int c = 0; c < table.Columns.Count; c++)
            {
                if (c > 0) csv.Append(',');
                csv.Append(table.Columns[c].ColumnName.Replace("_", " "));
            }
            csv.AppendLine();

            // values with commas or quotes need to be wrapped in quotes
            foreach (DataRow row in table.Rows)
            {
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    if (c > 0) csv.Append(',');
                    string value = row[c] is DateTime ? ((DateTime)row[c]).ToString("yyyy-MM-dd") : row[c].ToString();
                    if (value.Contains(",") || value.Contains("\""))
                        value = "\"" + value.Replace("\"", "\"\"") + "\"";
                    csv.Append(value);
                }
                csv.AppendLine();
            }

            // the BOM makes Excel show Arabic names correctly
            File.WriteAllText(path, csv.ToString(), new UTF8Encoding(true));
        }
    }
}
