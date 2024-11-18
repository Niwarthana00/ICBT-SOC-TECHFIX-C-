using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class edit_product : Form
    {
        private int productId;
        private string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";

        public edit_product(int productId)
        {
            InitializeComponent();
            this.productId = productId;
            LoadCategories();  // Load categories when form initializes
            LoadProductData(); // Load product data
        }

        private void LoadCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, category_name FROM category ORDER BY category_name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing items
                            category.Items.Clear();

                            // Create a Dictionary to store category_id and category_name
                            Dictionary<int, string> categories = new Dictionary<int, string>();

                            while (reader.Read())
                            {
                                int categoryId = reader.GetInt32(0);
                                string categoryName = reader.GetString(1);
                                categories.Add(categoryId, categoryName);

                                // Create a ComboBoxItem to store both ID and Name
                                ComboBoxItem item = new ComboBoxItem
                                {
                                    Value = categoryId,
                                    Text = categoryName
                                };

                                category.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadProductData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT item_name, description, price, category_id FROM items WHERE item_id = @productId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productname.Text = reader["item_name"].ToString();
                                description.Text = reader["description"].ToString();
                                price.Text = reader["price"].ToString();

                                // Set the selected category in dropdown
                                int categoryId = Convert.ToInt32(reader["category_id"]);

                                foreach (ComboBoxItem item in category.Items)
                                {
                                    if (item.Value == categoryId)
                                    {
                                        category.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category.SelectedItem != null)
            {
                ComboBoxItem selectedCategory = (ComboBoxItem)category.SelectedItem;
                // You can use selectedCategory.Value to get the category_id
                // and selectedCategory.Text to get the category_name
            }
        }

        // Custom class to store both ID and Name for ComboBox items
        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        // Your existing event handlers...
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void edit_product_Load(object sender, EventArgs e) { }
        // Add this for the cancel button if needed
        private void btncancel_Click(object sender, EventArgs e)
        {
            view_product viewProductForm = new view_product();
            viewProductForm.Show();
            this.Close();
        }
        private void description_TextChanged(object sender, EventArgs e) { }
        private void price_TextChanged(object sender, EventArgs e) { }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Validate inputs first
            if (string.IsNullOrWhiteSpace(productname.Text) ||
                string.IsNullOrWhiteSpace(description.Text) ||
                string.IsNullOrWhiteSpace(price.Text) ||
                category.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate price is a valid number
            if (!decimal.TryParse(price.Text, out decimal priceValue))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = @"UPDATE items 
                                 SET item_name = @itemName, 
                                     description = @description, 
                                     price = @price, 
                                     category_id = @categoryId 
                                 WHERE item_id = @productId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Get selected category ID
                        int selectedCategoryId = ((ComboBoxItem)category.SelectedItem).Value;

                        // Add parameters
                        command.Parameters.AddWithValue("@itemName", productname.Text.Trim());
                        command.Parameters.AddWithValue("@description", description.Text.Trim());
                        command.Parameters.AddWithValue("@price", priceValue);
                        command.Parameters.AddWithValue("@categoryId", selectedCategoryId);
                        command.Parameters.AddWithValue("@productId", productId);

                        // Execute update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate back to view_product form
                            view_product viewProductForm = new view_product();
                            viewProductForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the product.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            view_product ds = new view_product();
            ds.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            view_product ds = new view_product();
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