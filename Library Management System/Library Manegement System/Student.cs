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



namespace Library_Manegement_System
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            LoadStudents();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE students SET Student_Name=@Student_Name, Gender=@Gender, Email=@Email, Phone_Number=@Phone_Number, Address=@Address " +
               "WHERE studentid=@studentid", con);
            cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox6.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            LoadStudents();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (
        string.IsNullOrEmpty(textBox2.Text) ||
        string.IsNullOrEmpty(textBox3.Text) ||
        string.IsNullOrEmpty(textBox4.Text) ||
        string.IsNullOrEmpty(textBox5.Text) ||
        string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("You Cant Insert Null Data, Please Fill In All Fields!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO students (Student_Name, Gender, Email, Phone_Number, Address) " +
    "VALUES (@Student_Name, @Gender, @Email, @Phone_Number, @Address)", con);
            cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox6.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            LoadStudents(); 
        }

        private void LoadStudents()
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM students", con );
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt; 
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?",
              "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE studentid=@studentid", con);
                cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                LoadStudents();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["StudentID"].Value.ToString();
                textBox2.Text = row.Cells["Student_Name"].Value.ToString();
                textBox6.Text = row.Cells["Gender"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                textBox4.Text = row.Cells["Phone_Number"].Value.ToString();
                textBox5.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            LoadStudents(); 
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
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
