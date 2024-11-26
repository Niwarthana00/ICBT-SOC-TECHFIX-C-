using System;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            // Any initialization logic when the dashboard loads can go here.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label click here if needed.
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Custom drawing for panel, if needed.
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting for FlowLayoutPanel, if needed.
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create customer page form first
            customer_page customerForm = new customer_page();
            customerForm.Show();

            this.Hide();
        }


        private void label7_Click(object sender, EventArgs e)
        {
            // Close the current form when label7 is clicked
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            contact contact = new contact();
            contact.Show();

            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                login loginform = new login();
                loginform.Show();
                this.Hide();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            category_page category = new category_page();
            category.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            product_page product = new product_page();
            product.Show();

            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                login loginform = new login();
                loginform.Show();
                this.Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            contact customerForm = new contact();
            customerForm.Show();

            this.Hide();
        }
    }
}
