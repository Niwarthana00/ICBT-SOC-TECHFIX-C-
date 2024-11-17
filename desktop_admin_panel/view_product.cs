using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class view_product : Form
    {
        private DataGridView dataGridView; // Declare at class level

        public view_product()
        {
            InitializeComponent();
    }

        private void view_product_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            // Connection string for techfixdb database
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

            // SQL query to fetch appointment data
            string query = "SELECT item_id, item_name, description, price FROM items";

            // Create a DataTable to hold the data
            DataTable appointmentTable = new DataTable();

            // Connect to the database and retrieve data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(appointmentTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                    return;
                }
            }

            // Create and configure the DataGridView if not added in designer
            DataGridView dataGridView = new DataGridView
            {
                DataSource = appointmentTable,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = System.Drawing.Color.Black,
                ForeColor = System.Drawing.SystemColors.ButtonHighlight,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.Gray,
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.Black,
                    ForeColor = System.Drawing.Color.White
                }
            };

            // Clear previous controls in TableLayoutPanel to avoid duplication
            tableLayoutPanel1.Controls.Clear();

            // Add the DataGridView to the TableLayoutPanel and span across all columns
            tableLayoutPanel1.Controls.Add(dataGridView, 0, 0);
            tableLayoutPanel1.SetColumnSpan(dataGridView, tableLayoutPanel1.ColumnCount);  // Span across all columns

            // Adjust TableLayoutPanel's row styles to fit DataGridView properly
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the button column
            if (e.ColumnIndex == dataGridView.Columns["Action"].Index && e.RowIndex >= 0)
            {
                // Retrieve the item_id of the selected row
                int itemId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["item_id"].Value);

                // Display a message or perform any action you want with the item_id
                MessageBox.Show($"View details for item ID: {itemId}");

                // You can add any additional code here to open a new form or show item details
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
