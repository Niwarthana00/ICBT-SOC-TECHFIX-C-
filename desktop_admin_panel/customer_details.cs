using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace desktop_admin_panel
{
    public partial class customer_details : Form
    {
        // Connection string - replace with your actual database details
        private string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";
        private DataTable customerData;


        public customer_details()
        {
            InitializeComponent();
            SetupTableLayout();
            LoadCustomerData();
        }

        private void SetupTableLayout()
        {
            // Clear existing controls
            tableLayoutPanel1.Controls.Clear();

            // Add column headers
            string[] headers = { "ID", "Full Name", "Address", "Contact Number", "Email", "Password" };
            for (int i = 0; i < headers.Length; i++)
            {
                Label headerLabel = new Label
                {
                    Text = headers[i],
                    Font = new Font(Font, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray
                };
                tableLayoutPanel1.Controls.Add(headerLabel, i, 0);
            }
        }

        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ID, FullName, Address, ContactNumber, Email FROM Users";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        customerData = new DataTable();
                        adapter.Fill(customerData);
                    }
                }

                // Display data in tableLayoutPanel
                DisplayCustomerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCustomerData()
        {
            // Clear existing data rows (keep headers)
            while (tableLayoutPanel1.RowCount > 1)
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    Control ctrl = tableLayoutPanel1.GetControlFromPosition(i, 1);
                    if (ctrl != null)
                    {
                        tableLayoutPanel1.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }
                tableLayoutPanel1.RowCount--;
            }

            // Add rows for data
            if (customerData != null && customerData.Rows.Count > 0)
            {
                tableLayoutPanel1.RowCount = customerData.Rows.Count + 1; // +1 for header row

                // Set row styles
                float rowHeight = 100f / (customerData.Rows.Count + 1);
                tableLayoutPanel1.RowStyles.Clear();
                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
                }

                // Add data
                for (int row = 0; row < customerData.Rows.Count; row++)
                {
                    for (int col = 0; col < customerData.Columns.Count; col++)
                    {
                        Label dataLabel = new Label
                        {
                            Text = customerData.Rows[row][col].ToString(),
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Mask password field
                        if (col == 5) // Password column
                        {
                            dataLabel.Text = "********";
                        }

                        tableLayoutPanel1.Controls.Add(dataLabel, col, row + 1);
                    }
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint event handler - can be used for custom drawing if needed
        }

        // Add refresh button click handler if you have one
        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void customer_details_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            customer_page customer = new customer_page();
            customer.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            customer_page customer = new customer_page();
            customer.Show();
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
    }
}