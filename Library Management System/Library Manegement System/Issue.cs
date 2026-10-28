using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Library_Manegement_System
{
    public partial class Issue : Form
    {
        public Issue()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (
        string.IsNullOrEmpty(textBox2.Text) ||
        string.IsNullOrEmpty(textBox6.Text) )
        
            {
                MessageBox.Show("You Cant Insert Null Data, Please Fill In All Fields!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }








            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO issue (StudentID, BookID, Issue_Date, Due_Date, Return_Date) " +
    "VALUES (@StudentID, @BookID, @Issue_Date, @Due_Date, @Return_Date)", con);
            cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@BookID", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Issue_Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Due_Date",   dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@Return_Date",dateTimePicker3.Value.Date);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            LoadIssue();
        }
        private void LoadIssue()
        {

            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM issue", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView3.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE issue SET StudentID=@StudentID, BookID=@BookID, Issue_Date=@Issue_Date, Due_Date=@Due_Date, Return_Date=@Return_Date " +
               "WHERE issueid=@issueid", con);
            cmd.Parameters.AddWithValue("@IssueID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@BookID", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Issue_Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Due_Date", dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@Return_Date", dateTimePicker3.Value.Date);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            LoadIssue();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?",
              "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM issue WHERE issueid=@issueid", con);
                cmd.Parameters.AddWithValue("@IssueID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                LoadIssue();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];

                textBox1.Text = row.Cells["IssueID"].Value.ToString();
                textBox2.Text = row.Cells["StudentID"].Value.ToString();
                textBox6.Text = row.Cells["BookID"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Issue_Date"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["Due_Date"].Value);
                dateTimePicker3.Value = Convert.ToDateTime(row.Cells["Return_Date"].Value);
            }
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            LoadIssue();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
