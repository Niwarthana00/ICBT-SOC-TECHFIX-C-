using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class addcategory : Form
    {
        public addcategory()
        {
            InitializeComponent();
            this.Load += addcategory_Load; // Attach the Load event
        }

        private void addcategory_Load(object sender, EventArgs e)
        {
            // Set text color to white and background to black
            richTextBox1.ForeColor = Color.White;
            richTextBox1.BackColor = Color.Black; // Optional
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close current form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoryName = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Connection string - replace with your database details
                string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert category
                    string query = "INSERT INTO category (category_name, image_name) VALUES (@category_name, @image_name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@category_name", categoryName);
                        command.Parameters.AddWithValue("@image_name", ""); // Empty image_name

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            richTextBox1.Clear(); // Clear the text box after adding
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close(); // Close form on label click
        }
    }
}
