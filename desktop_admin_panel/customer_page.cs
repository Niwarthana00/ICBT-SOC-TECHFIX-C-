using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class customer_page : Form
    {
        public customer_page()
        {
            InitializeComponent();
        }

        private void customer_page_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the CustomerDetails form
            view_product product = new view_product();

            // Show the CustomerDetails form as a modal dialog
            product.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the CustomerDetails form
            appo customerForm = new appo();

            // Show the CustomerDetails form as a modal dialog
            customerForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
