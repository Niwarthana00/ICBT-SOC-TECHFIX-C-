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
            // Another label click handler, if needed.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the Customer form
            customer_page customerForm = new customer_page();

            // Show the Customer form as a modal dialog
            customerForm.ShowDialog();

            // Close the current form (this form) after the modal dialog is closed
            this.Close();
        }


        private void label7_Click(object sender, EventArgs e)
        {
            // Close the current form when label7 is clicked
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            order_place customerForm = new order_place();

            // Show the Customer form as a modal dialog
            customerForm.ShowDialog();

            // Close the current form (this form) after the modal dialog is closed
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            view_category customerForm = new view_category();

            // Show the Customer form as a modal dialog
            customerForm.ShowDialog();

            // Close the current form (this form) after the modal dialog is closed
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            product_page productpage = new product_page();

            // Show the Customer form as a modal dialog
            productpage.ShowDialog();

            // Close the current form (this form) after the modal dialog is closed
            this.Close();
        }
    }
}
