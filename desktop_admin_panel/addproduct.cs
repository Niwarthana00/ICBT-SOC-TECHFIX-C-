using System;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class addproduct : Form
    {
        private string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";

        public addproduct()
        {
            InitializeComponent();
            LoadCategories(); 
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, category_name FROM category";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable categoryTable = new DataTable();
                        adapter.Fill(categoryTable);

                        comboBox1.DataSource = categoryTable;
                        comboBox1.DisplayMember = "category_name";
                        comboBox1.ValueMember = "id";
                        comboBox1.SelectedIndex = -1; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        // Event for the Add button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the entered data
            string itemName = textBox1.Text.Trim();
            string description = richTextBox1.Text.Trim();
            string priceText = textBox3.Text.Trim();
            int? categoryId = comboBox1.SelectedValue as int?;

            // Validate inputs
            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(priceText) || categoryId == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            try
            {
                // Save the data to the items table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO items (item_name, description, price, category_id) VALUES (@itemName, @description, @price, @categoryId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@itemName", itemName);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully.");

                        // Clear the fields after successful save
                        textBox1.Clear();
                        richTextBox1.Clear();
                        textBox3.Clear();
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            product_page ds = new product_page();
            ds.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            product_page ds = new product_page();
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
