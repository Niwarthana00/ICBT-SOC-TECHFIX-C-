using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace techfix.supplier1
{
    public partial class editproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadProductDetails(productId);
                }
            }
        }

        private void LoadProductDetails(int productId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "SELECT product_name, price, description, qty, image FROM s1product WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", productId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtProductName.Text = reader["product_name"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                    txtAvailability.Text = reader["qty"].ToString();

                    string imagePath = reader["image"].ToString();
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        imgPreview.ImageUrl = imagePath;
                        imgPreview.Visible = true;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "UPDATE s1product SET product_name = @productName, price = @price, description = @description, qty = @qty, image = @image WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@productName", txtProductName.Text);
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                command.Parameters.AddWithValue("@description", txtDescription.Text);
                command.Parameters.AddWithValue("@qty", Convert.ToInt32(txtAvailability.Text));

                // Handle image upload if a new file is selected
                string imagePath = imgPreview.ImageUrl;  // Default to current image
                if (fileUploadImage.HasFile)
                {
                    string fileName = Path.GetFileName(fileUploadImage.FileName);
                    imagePath = "~/admin_panel/img/" + fileName;
                    fileUploadImage.SaveAs(Server.MapPath(imagePath));
                }
                command.Parameters.AddWithValue("@image", imagePath);

                command.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

                connection.Open();
                command.ExecuteNonQuery();

                lblMessage.Text = "Product updated successfully!";
                lblMessage.Visible = true;

                // Redirect after a brief delay
                Response.AddHeader("REFRESH", "2;URL=showproduct.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("showproduct.aspx");
        }
    }
}
