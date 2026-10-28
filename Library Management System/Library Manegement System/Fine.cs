using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Fine : Form
    {
        public Fine()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE fine SET IssueID=@IssueID , Amount=@Amount  " +
               "WHERE fineid=@fineid ", con);
            cmd.Parameters.AddWithValue("@FineID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@IssueID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            LoadFine();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?",
               "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM fine WHERE fineid=@fineid ", con);
                cmd.Parameters.AddWithValue("@FineID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                LoadFine();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            
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
            SqlCommand cmd = new SqlCommand("INSERT INTO fine (IssueID, Amount) " +
                "VALUES (@IssueID, @Amount)", con);
            cmd.Parameters.AddWithValue("@IssueID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            LoadFine();
        }

        private void LoadFine()
        {

            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fine", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView5.DataSource = dt;

        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];

                textBox1.Text = row.Cells["FineID"].Value.ToString();
                textBox2.Text = row.Cells["IssueID"].Value.ToString();
                textBox6.Text = row.Cells["Amount"].Value.ToString();
               
            }
        }

        private void Fine_Load(object sender, EventArgs e)
        {
            LoadFine(); 
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
