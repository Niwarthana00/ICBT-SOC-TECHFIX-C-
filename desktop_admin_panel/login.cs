using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class login : Form
    {
        // Replace with your actual connection string
         string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";

        public login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Query to check user credentials
            string query = "SELECT COUNT(1) FROM UserRole WHERE Email = @Email AND Password = @Password AND Role = 'Admin'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount == 1)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dashboard dashboardForm = new dashboard();
                            dashboardForm.Show(); // Show the dashboard form
                            this.Hide(); // Hide the login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password, or you are not authorized to access this system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your email...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter your email...";
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter your password...")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter your password...";
                textBox2.ForeColor = System.Drawing.Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            // Set placeholders on load
            textBox1.Text = "Enter your email...";
            textBox1.ForeColor = System.Drawing.Color.Gray;

            textBox2.Text = "Enter your password...";
            textBox2.ForeColor = System.Drawing.Color.Gray;
            textBox2.UseSystemPasswordChar = false;
        }
    }
}
