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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num=0;
            try
            {
                 num = Convert.ToInt32(textBox2.Text);
            }
            catch(Exception ex){
                Console.Out.Write(ex);
            }


            if (num % 4 == 0)
            {
                Console.Out.Write(num.ToString()+"= Number of seats");
                try
                {

                    //cmd.Connection = conn;
                    SqlConnection conn = new SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(" insert into FlightInfo (FlightNo,SeatingCapacity,PriceFirstClass,PriceEconomyClass,DepartureTime,ArrivalTime,DepartureAirport,ArrivalAirport) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Flight " + textBox1.Text + " has been added into the Database ");
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();

                }

                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else { MessageBox.Show("Number of Seats in the Flights needs to be divisible by 4"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
