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
//using System.Windows.Controls;



namespace WindowsFormsApplication1
{
    public partial class Seating : Form
    {
        string[] seats;
        string Occupied;
        public Seating(string flightNo)
        {
            InitializeComponent();
            textBox4.Text = flightNo;
        }

        private void Seating_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new  SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select SeatOccupied from FlightInfo  where  FlightNo = '" + textBox4.Text + "'", conn);
            DataTable dt = new DataTable();
            
            sda.Fill(dt);
            
             Occupied = dt.Rows[0][0].ToString();
            MessageBox.Show(Occupied);

             //string Occupied = "5B,6C,7C";
            seats = Occupied.Split(',');
            textBox1.Show();
            this.textBox1.Height = 100;
            int total_seats = 50;
            int rows = 50 / 4;
            int columns = 4;
            char row_alpha;
            textBox1.Text = textBox1.Text + "  ";
            for (int i = 0; i < rows;i++ )
            {
                textBox1.Text = textBox1.Text + "   "+(i+1).ToString();
            }
            textBox1.Text = textBox1.Text + "\r\n";

                for (int j = 0; j < columns; j++)
                {
                    if (j == 0)
                    {
                        textBox1.Text = textBox1.Text + "A ";
                        row_alpha = 'A';
                    }
                    else if (j == 1)
                    {
                        textBox1.Text = textBox1.Text + "B ";
                        row_alpha = 'B';
                    }
                    else if (j == 2)
                    {
                        textBox1.Text = textBox1.Text + "\r\n";
                        textBox1.Text = textBox1.Text + "C ";
                        row_alpha = 'C';
                    }
                    else { textBox1.Text = textBox1.Text + "D ";
                    row_alpha = 'D';
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        bool empty=true;
                        string test_seat = (i + 1).ToString()+ row_alpha.ToString();
                        Console.Out.WriteLine(test_seat);
                        for (int k = 0; k < seats.Length; k++)
                        {   
                            if (seats[k] == test_seat)
                            {
                                
                                empty = false;
                            }
                        }
                        if (empty == false)
                        { textBox1.Text = textBox1.Text + "  X"; }
                        else {
                            textBox1.Text = textBox1.Text + "  O";
                        }
                    }

                    textBox1.Text = textBox1.Text + "\r\n";
                }
             
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            string seatno;
            if (textBox3.Text.ToString() == " ")
            {
                MessageBox.Show("Please Enter Valid Seat Number");
            }
            else
            {
                int length=0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (seats[i].Equals(textBox3.Text.ToString()))
                    {
                        MessageBox.Show("Seat is Occupied,Please choose another seat");
                        break;
                    }
                    length++;
                }
                if(length==seats.Length)
                {   
                    seatno=textBox3.Text.ToString();
                    Occupied=Occupied+seatno+",";
                    SqlConnection conn = new SqlConnection(@"Data Source=YASHPC\SQLEXPRESS;Initial Catalog=YashDb;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("Update  flightInfo SET SeatOccupied= '" + Occupied + "' where flightNo='" + textBox4.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                this.Hide();
                    ConfirmationPage cf = new ConfirmationPage(textBox4.Text,seatno);
                    cf.Show();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
