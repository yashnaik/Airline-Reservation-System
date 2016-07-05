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
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try {
                
                //cmd.Connection = conn;
                SqlConnection conn = new SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
                //SqlCommand cmd = new SqlCommand("insert into Table1 (Id,name,password) values ('" + textBox1.Text + "','" + textBox2.Text +"'',"+textBox "')",conn);
                //SqlDataReader dr;
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Table1 where name= '" + textBox1.Text+ "' and password ='" + textBox2.Text+ "' ",conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if(textBox1.Text.ToString().Equals("admin")){
                        MessageBox.Show("Welcome Admin, you are allowed to add flights");
                        this.Hide();
                        Form2 flight = new Form2();
                        flight.Show();
                    }
                    else if (textBox1.Text.ToString().Equals("user")){
                        MessageBox.Show("Welcome Guest, you will directed to Flight Booking Window");
                        this.Hide();
                        UserBookingForm f1 = new UserBookingForm();
                        f1.Show();

                    
                    }
                }
                else {
                    MessageBox.Show("Else");
                }
               // cmd.CommandText= "insert into Table (Id,Name) values ('"+ textBox1.Text + "','"+textBox2.Text +"')";
                


            }

            catch (SqlException ex){
            MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
