using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class view_product : Form
    {
        private DataGridView dataGridView;
        private int selectedItemId;
        private string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

        public view_product()
        {
            InitializeComponent();
            this.Activated += View_Product_Activated;
        }

        private void View_Product_Activated(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void view_product_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            string query = @"SELECT i.item_id, i.item_name, i.description, i.price, c.category_name 
                           FROM items i 
                           LEFT JOIN category c ON i.category_id = c.id 
                           ORDER BY i.item_id DESC";

            DataTable productTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(productTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (dataGridView == null)
            {
                dataGridView = new DataGridView
                {
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

                dataGridView.CellClick += DataGridView_CellClick;

                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(dataGridView, 0, 0);
                tableLayoutPanel1.SetColumnSpan(dataGridView, tableLayoutPanel1.ColumnCount);

                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel1.RowCount = 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            }

            dataGridView.DataSource = productTable;

            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns["item_id"].HeaderText = "ID";
                dataGridView.Columns["item_name"].HeaderText = "Product Name";
                dataGridView.Columns["description"].HeaderText = "Description";
                dataGridView.Columns["price"].HeaderText = "Price";
                dataGridView.Columns["category_name"].HeaderText = "Category";

                dataGridView.Columns["price"].DefaultCellStyle.Format = "C2";
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                if (int.TryParse(dgv.Rows[e.RowIndex].Cells["item_id"].Value?.ToString(), out int itemId))
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
                edit_product editForm = new edit_product(selectedItemId);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedItemId <= 0)
            {
                MessageBox.Show("Please select a product to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the product name for the confirmation message
            string productName = "";
            if (dataGridView.SelectedRows.Count > 0)
            {
                productName = dataGridView.SelectedRows[0].Cells["item_name"].Value.ToString();
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the product '{productName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Proceed with deletion
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM items WHERE item_id = @itemId";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@itemId", selectedItemId);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Reset selected ID
                                selectedItemId = 0;

                                // Refresh the grid to show updated data
                                LoadProducts();
                            }
                            else
                            {
                                MessageBox.Show("Product could not be deleted. It may have already been removed.",
                                    "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void label7_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}