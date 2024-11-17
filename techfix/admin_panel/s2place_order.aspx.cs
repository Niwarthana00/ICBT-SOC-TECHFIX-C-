// s1place_order.aspx.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using static techfix.admin_panel.supplier2_order;

namespace techfix.admin_panel
{
    public partial class s2place_order : Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optionally load existing data or setup
            }
        }

        protected void PayNowButton_Click(object sender, EventArgs e)
        {
            string customerName = NameTextBox.Text.Trim();
            string customerNumber = NumberTextBox.Text.Trim();

            List<Product> selectedItems = Session["SelectedItems"] as List<Product>;

            if (selectedItems != null && selectedItems.Count > 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    foreach (var item in selectedItems)
                    {
                        string query = "INSERT INTO s2order (CustomerName, CustomerNumber, ProductId, ProductName, Quantity, Price) VALUES (@CustomerName, @CustomerNumber, @ProductId, @ProductName, @Quantity, @Price)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CustomerName", customerName);
                            cmd.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                            cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmd.Parameters.AddWithValue("@ProductName", item.ProductName);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@Price", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Clear session and redirect or show a success message
                Session["SelectedItems"] = null;
                Response.Redirect("dashboard.aspx"); // Create a success page to inform the user
            }
        }
    }
}
