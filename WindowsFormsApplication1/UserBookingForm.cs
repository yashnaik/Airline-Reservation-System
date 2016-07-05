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

namespace WindowsFormsApplication1
{
    public partial class UserBookingForm : Form
    {
        public UserBookingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from flightinfo ",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Enter Flight number here";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seating ss = new Seating(textBox1.Text);
            ss.Show();
        }

        
    }

        
}
