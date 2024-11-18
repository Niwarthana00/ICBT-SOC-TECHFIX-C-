using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class order_place : Form
    {
        public order_place()
        {
            InitializeComponent();
        }

        private void order_place_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.White;
            Loadorder();
        }
        private void order_place_Load_1(object sender, EventArgs e)
        {
            // Add logic for the form's Load event, if necessary.
        }

        private void Loadorder()
        {
            // Connection string for techfixdb database
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT orderid, customer_name, phone_number, address, item_name, quantity, price, order_total, order_date FROM customerorder";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear previous controls and dynamically generate rows/columns
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowStyles.Clear();
                    tableLayoutPanel1.ColumnStyles.Clear();

                    // Set the number of rows and columns
                    tableLayoutPanel1.RowCount = dataTable.Rows.Count + 1; // Add 1 for header
                    tableLayoutPanel1.ColumnCount = dataTable.Columns.Count;

                    // Set headers
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        Label header = new Label
                        {
                            Text = dataTable.Columns[col].ColumnName,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.LightGray,
                            AutoSize = true,
                            Dock = DockStyle.Fill
                        };
                        tableLayoutPanel1.Controls.Add(header, col, 0);
                    }

                    // Populate rows with data
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            Label cell = new Label
                            {
                                Text = dataTable.Rows[row][col].ToString(),
                                TextAlign = ContentAlignment.MiddleCenter,
                                BackColor = Color.White,
                                AutoSize = true,
                                Dock = DockStyle.Fill
                            };
                            tableLayoutPanel1.Controls.Add(cell, col, row + 1);
                        }
                    }

                    // Adjust row and column styles for proper layout
                    for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                    {
                        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / tableLayoutPanel1.ColumnCount));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            ds.Show();
            this.Hide();
        }
        



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // No custom paint logic required.
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
    }
}
