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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {


            if (
        string.IsNullOrEmpty(textBox2.Text) ||
        string.IsNullOrEmpty(textBox6.Text) ||
        string.IsNullOrEmpty(textBox3.Text) )
        
            {
                MessageBox.Show("You Cant Insert Null Data, Please Fill In All Fields!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO books (Book_Name, Author, Publisher) " +
                "VALUES (@Book_Name, @Author, @Publisher)", con);
            cmd.Parameters.AddWithValue("@Book_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox6.Text);
            cmd.Parameters.AddWithValue("@Publisher", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            LoadBooks();
        }

        private void LoadBooks()
        {

            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM books", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView2.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE books SET Book_Name=@Book_Name , Author=@Author , Publisher=@Publisher " +
               "WHERE bookid=@bookid ", con);
            cmd.Parameters.AddWithValue("@BookID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Book_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox6.Text);
            cmd.Parameters.AddWithValue("@Publisher", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            LoadBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?",
               "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM books WHERE bookid=@bookid ", con);
                cmd.Parameters.AddWithValue("@BookID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                LoadBooks();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox3.Clear();
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                textBox1.Text = row.Cells["BookID"].Value.ToString();
                textBox2.Text = row.Cells["Book_Name"].Value.ToString();
                textBox6.Text = row.Cells["Author"].Value.ToString();
                textBox3.Text = row.Cells["Publisher"].Value.ToString();
            }
        }

        private void Book_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block the key
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block the key
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block the key
            }
        }
    }
}

