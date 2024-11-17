using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class view_product : Form
    {
        private DataGridView dataGridView; // Declare DataGridView at class level
        private int selectedItemId; // Store the selected item's ID

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

            // Create and configure the DataGridView
            dataGridView = new DataGridView
            {
                DataSource = appointmentTable,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
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

            // Attach CellClick event handler
            dataGridView.CellClick += DataGridView_CellClick;

            // Clear previous controls in TableLayoutPanel to avoid duplication
            tableLayoutPanel1.Controls.Clear();

            // Add the DataGridView to the TableLayoutPanel
            tableLayoutPanel1.Controls.Add(dataGridView, 0, 0);
            tableLayoutPanel1.SetColumnSpan(dataGridView, tableLayoutPanel1.ColumnCount);

            // Adjust TableLayoutPanel's row styles
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid row and not the header row
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = sender as DataGridView;

                // Try to parse the selected item's ID
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["item_id"].Value?.ToString(), out int itemId))
                {
                    selectedItemId = itemId;
                }
                else
                {
                    MessageBox.Show("Invalid ID value. Please ensure it is a valid integer.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedItemId > 0)
            {
                // Open the edit_product form and pass the selected item ID
                edit_product editForm = new edit_product(selectedItemId);
                editForm.ShowDialog(); // Use ShowDialog to make it modal
            }
            else
            {
                MessageBox.Show("No row selected. Please select a row first.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
