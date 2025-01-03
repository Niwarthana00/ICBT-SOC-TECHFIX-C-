﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class edit_category : Form
    {
        private int categoryId;
        private string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=techfixdb;Integrated Security=True";

        // Constructor to accept category ID and fetch the category name
        public edit_category(int categoryId)
        {
            InitializeComponent();
            this.categoryId = categoryId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to fetch the category name by ID
                    string query = "SELECT category_name FROM category WHERE id = @categoryId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        // Execute the query and fetch the result
                        object result = command.ExecuteScalar();

                        // Check if a result was found
                        if (result != null)
                        {
                            // Set the category name to the RichTextBox
                            richTextBox1.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle potential errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_category_Load(object sender, EventArgs e)
        {
            // You can add any additional logic here when the form loads.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updatedCategoryName = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(updatedCategoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to update the category name by ID
                    string query = "UPDATE category SET category_name = @categoryName WHERE id = @categoryId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@categoryName", updatedCategoryName);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the current form
                            this.Hide();

                            // Open the view_category form
                            view_category viewCategoryForm = new view_category();
                            viewCategoryForm.ShowDialog();

                            // Close this form completely
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Category update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle potential errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text change logic if needed, for now, it is not being used.
        }

        private void edit_category_Load_1(object sender, EventArgs e)
        {
            // You can add any additional logic here when the form loads again.
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            view_category ds = new view_category();
            ds.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            view_category ds = new view_category();
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