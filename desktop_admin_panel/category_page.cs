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
    public partial class category_page : Form
    {
        public category_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view_category viewcategory = new view_category();
            viewcategory.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcategory addcategory = new addcategory();
            addcategory.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
