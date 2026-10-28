using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Manegement_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display1();
            display2();
            display3();
        }


        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM students", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount1.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM books", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount2.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount2.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=AMR_AHMED25\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM librarians", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount3.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount3.Text = "0";
            }
            con.Close(); //Remember close the connection
        }
    }
}
