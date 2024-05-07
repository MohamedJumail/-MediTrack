using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace PTproject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

           

            Int64 contact = Convert.ToInt64(textBox2.Text);

            DateTime selectedDate = dateTimePicker1.Value;



            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO book VALUES (@pname, @pno, @date)", con))
                    {
                        com.Parameters.AddWithValue("@pname", name);

                        com.Parameters.AddWithValue("@pno", contact);
                        com.Parameters.AddWithValue("@date", selectedDate);
                       



                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MessageBox.Show("Appointment Booked");
            textBox1.Clear();
            textBox2.Clear();
           


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
