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
    public partial class product_page : Form
    {
        public product_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the CustomerDetails form
            customer_details customerForm = new customer_details();

            // Show the CustomerDetails form as a modal dialog
            customerForm.ShowDialog();
        }
    }
}
