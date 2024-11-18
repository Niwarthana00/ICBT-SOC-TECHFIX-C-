using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class view_category : Form
    {
        int clickedCategoryId = 0;

        public view_category()
        {
            InitializeComponent();
        }

        private void view_category_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            // Connection string for techfixdb database
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

            // SQL query to fetch appointment data
            string query = "SELECT id, category_name FROM category";

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

            // Attach the CellClick event
            dataGridView.CellClick += DataGridView_CellClick;

            // Clear previous controls in TableLayoutPanel to avoid duplication
            tableLayoutPanel1.Controls.Clear();

            // Add the DataGridView to the TableLayoutPanel and span across all columns
            tableLayoutPanel1.Controls.Add(dataGridView, 0, 0);
            tableLayoutPanel1.SetColumnSpan(dataGridView, tableLayoutPanel1.ColumnCount);

            // Adjust TableLayoutPanel's row styles to fit DataGridView properly
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
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["id"].Value?.ToString(), out int categoryId))
                {
                    clickedCategoryId = categoryId;
                }
                else
                {
                    MessageBox.Show("Invalid ID value. Please ensure it is a valid integer.");
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (clickedCategoryId == 0)
            {
                MessageBox.Show("Please select a category to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            edit_category product = new edit_category(clickedCategoryId);
            product.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clickedCategoryId == 0)
            {
                MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Connection string for techfixdb database
                string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // SQL query to delete the category by ID
                        string query = "DELETE FROM category WHERE id = @categoryId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Use parameters to prevent SQL injection
                            command.Parameters.AddWithValue("@categoryId", clickedCategoryId);

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the DataGridView after deletion
                                LoadAppointments();
                            }
                            else
                            {
                                MessageBox.Show("No category was found with the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            category_page ds = new category_page();
            ds.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            category_page ds = new category_page();
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
    }
}
