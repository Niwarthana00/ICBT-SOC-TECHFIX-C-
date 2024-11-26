using System;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Validate email field
            if (string.IsNullOrWhiteSpace(email) || email == "Enter your email...")
            {
                MessageBox.Show("Please enter your email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // Validate password field
            if (string.IsNullOrWhiteSpace(password) || password == "Enter your password...")
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // Validate credentials (replace "bba" and "umma" with your actual credentials)
            if (email == "admin@example.com" && password == "admin123")
            {

                

                dashboard dashboardForm = new dashboard(); // Assuming `dashboard` is another form in your project
                dashboardForm.Show();                                            // Hide the current login form

              
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                textBox2.ForeColor = System.Drawing.Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Gray;

            textBox2.ForeColor = System.Drawing.Color.Gray;
            textBox2.UseSystemPasswordChar = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
