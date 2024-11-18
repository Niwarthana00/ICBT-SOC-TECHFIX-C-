using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class login : Form
    {
        // Database connection string
        string connectionString = "your_connection_string_here"; // Replace with your actual connection string

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password AND usertype = 'admin'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);  
                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount == 1)
                    {
                        MessageBox.Show("Login Successful!");
                        dashboard dashboardForm = new dashboard();  // Create an instance of the dashboard form
                        dashboardForm.Show();  // Show the dashboard form
                        this.Hide();  // Hide the login form (optional)
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password, or you are not an admin.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your text here...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter your text here...";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter your text here...")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter your text here...";
                textBox2.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
