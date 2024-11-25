using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private int itemId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["item_id"] != null)
                {
                    itemId = Convert.ToInt32(Request.QueryString["item_id"]);
                    ViewState["itemId"] = itemId; // Store itemId for postbacks
                    LoadProductDetails();
                }
            }
            else
            {
                // Retrieve itemId during postback
                itemId = ViewState["itemId"] != null ? Convert.ToInt32(ViewState["itemId"]) : 0;
            }
        }

        private void LoadProductDetails()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT item_name, description, price, image_name FROM items WHERE item_id = @item_id", conn);
                    cmd.Parameters.AddWithValue("@item_id", itemId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtItemName.Text = reader["item_name"].ToString();
                        txtDescription.Text = reader["description"].ToString();
                        txtPrice.Text = reader["price"].ToString();
                        textImageURL.Text = reader["image_name"].ToString();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading product details: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            try
            {
                if (ValidateInputs())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE items SET item_name = @item_name, description = @description, price = @price, image_name = @image_name WHERE item_id = @item_id", conn);

                        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@image_name", textImageURL.Text);
                        cmd.Parameters.AddWithValue("@item_id", itemId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Product updated successfully!";
                        }
                        else
                        {
                            lblMessage.Text = "Update failed. Please try again.";
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Please fill in all required fields correctly.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error updating product: " + ex.Message;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                !decimal.TryParse(txtPrice.Text, out _) ||
                string.IsNullOrWhiteSpace(textImageURL.Text))
            {
                return false;
            }
            return true;
        }
    }
}
