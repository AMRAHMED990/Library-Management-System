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
    public partial class Librarian : Form
    {
        public Librarian()
        {
            InitializeComponent();
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
            SqlCommand cmd = new SqlCommand("INSERT INTO librarians (Name, Email, Phone_Number) " +
                "VALUES (@Name, @Email, @Phone_Number)", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            LoadLibrarians();
        }


        private void LoadLibrarians()
        {

            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM librarians", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView4.DataSource = dt;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE librarians SET Name=@Name , Email=@Email , Phone_Number=@Phone_Number " +
               "WHERE librarianid=@librarianid ", con);
            cmd.Parameters.AddWithValue("@LibrarianID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox6.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            LoadLibrarians();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?",
               "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM librarians WHERE librarianid=@librarianid ", con);
                cmd.Parameters.AddWithValue("@LibrarianID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                LoadLibrarians();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox3.Clear();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                textBox1.Text = row.Cells["LibrarianID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox6.Text = row.Cells["Email"].Value.ToString();
                textBox3.Text = row.Cells["Phone_Number"].Value.ToString();
            }
        }

        private void Librarian_Load(object sender, EventArgs e)
        {
            LoadLibrarians(); 
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // block the key
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
