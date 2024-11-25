using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace techfix.admin_panel
{
    public partial class compare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No specific logic in Page_Load
        }

        protected void Supplier1SearchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSupplierDetails(Supplier1SearchBox.Text, "s1product", Supplier1Name, Supplier1Description, Supplier1Price, Supplier1Image);
        }

        protected void Supplier2SearchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSupplierDetails(Supplier2SearchBox.Text, "s2product", Supplier2Name, Supplier2Description, Supplier2Price, Supplier2Image);
        }

        private void UpdateSupplierDetails(string searchKeyword, string tableName, Label nameLabel, Label descriptionLabel, Label priceLabel, Image productImage)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                nameLabel.Text = "Not Found";
                descriptionLabel.Text = string.Empty;
                priceLabel.Text = string.Empty;
                productImage.ImageUrl = string.Empty;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"SELECT product_name, description, price, image FROM {tableName} WHERE product_name LIKE @search OR description LIKE @search";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            nameLabel.Text = reader["product_name"].ToString();
                            descriptionLabel.Text = reader["description"].ToString();
                            priceLabel.Text = reader["price"].ToString();

                            string imagePath = reader["image"].ToString();
                            productImage.ImageUrl = ResolveUrl( imagePath);
                        }
                        else
                        {
                            nameLabel.Text = "Not Found";
                            descriptionLabel.Text = string.Empty;
                            priceLabel.Text = string.Empty;
                            productImage.ImageUrl = string.Empty;
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                nameLabel.Text = "Error";
                descriptionLabel.Text = ex.Message;
                priceLabel.Text = string.Empty;
                productImage.ImageUrl = string.Empty;
            }
        }

        protected void Supplier1BuyNowBtn_Click(object sender, EventArgs e)
        {
            // Redirect to Supplier 1 order page with details
            Response.Redirect($"supplier1_order.aspx?productName={Supplier1Name.Text}&price={Supplier1Price.Text}");
        }

        protected void Supplier2BuyNowBtn_Click(object sender, EventArgs e)
        {
            // Redirect to Supplier 2 order page with details
            Response.Redirect($"supplier2_order.aspx?productName={Supplier2Name.Text}&price={Supplier2Price.Text}");
        }

        [WebMethod]
        public static List<string> GetSupplier1Suggestions(string prefixText)
        {
            return GetProductSuggestions(prefixText, "s1product");
        }

        [WebMethod]
        public static List<string> GetSupplier2Suggestions(string prefixText)
        {
            return GetProductSuggestions(prefixText, "s2product");
        }

        private static List<string> GetProductSuggestions(string prefixText, string tableName)
        {
            List<string> suggestions = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"SELECT product_name FROM {tableName} WHERE product_name LIKE @search";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + prefixText + "%");

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            suggestions.Add(reader["product_name"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }

            return suggestions;
        }
    }
}
