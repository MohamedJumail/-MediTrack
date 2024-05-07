using System.Windows.Forms;

namespace PTproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user, pass;
            user = textBox1.Text;
            pass = textBox2.Text;


            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass) && comboBox1.SelectedIndex != -1)
            {

                if (user == "jumail" && pass == "2004" && comboBox1.SelectedItem.ToString() == "Admin")
                {
                    this.Hide();
                    Form2 fm = new Form2();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful!");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields before attempting to login.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the ComboBox before proceeding.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Hide();
                Form3 fm3 = new Form3();
                fm3.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            //textBox1.Text = selectedRow.Cells[0].Value.ToString();

        }
    }
}
