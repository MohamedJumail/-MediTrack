using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PTproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Red;
            label2.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;
            panel2.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
            panel3.Visible = true;

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string query = "SELECT hospital.*, diagnosis2.symptoms, diagnosis2.diagnosis, diagnosis2.medicine, diagnosis2.ward, diagnosis2.wardtype " +
                                   "FROM hospital " +
                                   "INNER JOIN diagnosis2 ON hospital.pid = diagnosis2.pid";

                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);


                            dataGridView2.DataSource = dataTable;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;


            panel3.Visible = false;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.ForeColor = System.Drawing.Color.Red;
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;
            panel1.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Red;
            label6.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;

            panel2.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.Red;
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            panel3.Visible = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox2.Text;
            Int64 contact = Convert.ToInt64(textBox3.Text);
            int age = Convert.ToInt32(textBox4.Text);
            string gender = comboBox1.Text;
            string blood = textBox6.Text;
            string any = textBox7.Text;
            int pid = Convert.ToInt32(textBox8.Text);

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO hospital VALUES (@name, @address, @contact, @age, @gender, @blood, @disease, @pid)", con))
                    {
                        com.Parameters.AddWithValue("@name", name);
                        com.Parameters.AddWithValue("@address", address);
                        com.Parameters.AddWithValue("@contact", contact);
                        com.Parameters.AddWithValue("@age", age);
                        com.Parameters.AddWithValue("@gender", gender);
                        com.Parameters.AddWithValue("@blood", blood);
                        com.Parameters.AddWithValue("@disease", any);
                        com.Parameters.AddWithValue("@pid", pid);

                        con.Open();
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MessageBox.Show("Data Saved");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.ResetText();

        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox13.Text))
            {
                if (int.TryParse(textBox13.Text, out int pid2))
                {
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hospital;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();


                        string query = "SELECT * FROM hospital WHERE pid = @pid";

                        using (SqlCommand com = new SqlCommand(query, con))
                        {
                            com.Parameters.AddWithValue("@pid", pid2);


                            using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);


                                dataGridView1.DataSource = dataTable;

                            }
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Int64 pid3 = Convert.ToInt64(textBox13.Text);
            string symptoms = textBox9.Text;
            string diagnosis = textBox5.Text;
            string medicine = textBox10.Text;
            string ward = comboBox3.Text;
            string wt = comboBox2.Text;
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO diagnosis2 VALUES (@pid, @symptoms, @diagnosis, @medicine, @ward, @wardtype)", con))
                    {
                        com.Parameters.AddWithValue("pid", pid3);
                        com.Parameters.AddWithValue("@symptoms", symptoms);
                        com.Parameters.AddWithValue("@diagnosis", diagnosis);
                        com.Parameters.AddWithValue("@medicine", medicine);
                        com.Parameters.AddWithValue("@ward", ward);
                        com.Parameters.AddWithValue("@wardtype", wt);


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
            MessageBox.Show("Data Saved");
            textBox5.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox13.Clear();
            comboBox2.ResetText();
            comboBox3.ResetText();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Red;
            label2.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;
            panel2.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
            panel3.Visible = true;


            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string query = "SELECT hospital.*, diagnosis2.symptoms, diagnosis2.diagnosis, diagnosis2.medicine, diagnosis2.ward, diagnosis2.wardtype " +
                                   "FROM hospital " +
                                   "INNER JOIN diagnosis2 ON hospital.pid = diagnosis2.pid";

                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);


                            dataGridView2.DataSource = dataTable;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox11.Text, out int pid))
                {
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();


                        string query = "SELECT hospital.*, diagnosis2.symptoms, diagnosis2.diagnosis, diagnosis2.medicine, diagnosis2.ward, diagnosis2.wardtype " +
                                       "FROM hospital " +
                                       "INNER JOIN diagnosis2 ON hospital.pid = diagnosis2.pid " +
                                       "WHERE hospital.pid = @pid";

                        using (SqlCommand com = new SqlCommand(query, con))
                        {
                            com.Parameters.AddWithValue("@pid", pid);

                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);


                                dataGridView2.DataSource = dataTable;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid patient ID (numeric value).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime date = dateTimePicker1.Value;

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string query = "SELECT * FROM book WHERE CONVERT (date,date) = @date";

                    using (SqlCommand com = new SqlCommand(query, con))
                    {

                        com.Parameters.AddWithValue("@date", date.Date);

                        con.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);


                            dataGridView3.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToDelete = dateTimePicker1.Value.Date;

                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();


                    string deleteQuery = "DELETE FROM book WHERE CONVERT(date, date) = @date";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, con))
                    {
                        deleteCommand.Parameters.AddWithValue("@date", dateToDelete);


                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Records for {dateToDelete.ToShortDateString()} deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show($"No records found for {dateToDelete.ToShortDateString()}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Red;
            panel2.Visible = false;
            panel1.Visible = false;
            panel4.Visible = true;
            panel3.Visible = false;
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string query = "SELECT * FROM book";

                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);


                            dataGridView3.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Get the values from the selected row
                string value1 = selectedRow.Cells[0].Value.ToString();
                string value2 = selectedRow.Cells[1].Value.ToString();

                // Append the values to TextBox1 and TextBox2 with a newline character
                textBox1.Text += value1 + Environment.NewLine;
                textBox2.Text += value2 + Environment.NewLine;
            }
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Get the values from the selected row
                string value1 = selectedRow.Cells[0].Value.ToString();

                // Parse the second value as an integer
                int value2;
                if (int.TryParse(selectedRow.Cells[1].Value.ToString(), out value2))
                {
                    // Append the values to TextBox1 and TextBox2 with a newline character
                    textBox1.Text += value1 + Environment.NewLine;
                    textBox2.Text += value2.ToString() + Environment.NewLine;
                }
                else
                {
                    // Handle the case where parsing fails (invalid integer)
                    MessageBox.Show("Invalid integer value in the second column.");
                }*/
            /*private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                // Check if a valid row is clicked and it's not a header row
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Retrieve the selected row
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Clone the row to add it to the second DataGridView
                    DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                    foreach (DataGridViewCell cell in selectedRow.Cells)
                    {
                        newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                    }

                    // Add the cloned row to the second DataGridView
                    dataGridView2.Rows.Add(newRow);
                }
            }*/
            /*
            // Assuming you want to sum the "Price" column in dataGridView2

decimal totalPrice = 0;

foreach (DataGridViewRow row in dataGridView2.Rows)
{
    // Check if the row is not a new row (which is typically used for adding new data)
    if (!row.IsNewRow)
    {
        // Assuming "Price" is the name of the column containing prices
        // Replace it with the actual name of your price column
        object priceValue = row.Cells["Price"].Value;

        // Check if the value is not null and can be converted to decimal
        if (priceValue != null && decimal.TryParse(priceValue.ToString(), out decimal price))
        {
            // Add the price to the total
            totalPrice += price;
        }
    }
}

// Now 'totalPrice' contains the sum of all prices in the "Price" column of dataGridView2
*/



        }
    }
}
