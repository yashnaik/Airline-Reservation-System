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
    public partial class ConfirmationPage : Form
    {
        public ConfirmationPage(string flightNo, string seatno)
        {
            InitializeComponent();
            textBox1.Text = flightNo;
            textBox2.Text = seatno;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into Confirmation (flightNo,SeatNo,Name,Passportno) values ( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Congratulations, your ticket is booked !!");
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }
    }
}
