using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book bk = new Book();
            bk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Issue ie = new Issue();
            ie.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Librarian ln = new Librarian();
            ln.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fine fe = new Fine();
            fe.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
