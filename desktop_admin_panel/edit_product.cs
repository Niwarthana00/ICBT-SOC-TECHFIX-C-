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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to fetch the category name by ID
                    string query = "SELECT item_name,description,price FROM items WHERE item_id = @productId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@productId", productId);

                        // Execute the query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate textboxes with retrieved data
                                productname.Text = reader["item_name"].ToString();
                                description.Text = reader["description"].ToString();
                                price.Text = reader["price"].ToString();
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
                    // Handle potential errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void edit_product_Load(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }
    }
}
