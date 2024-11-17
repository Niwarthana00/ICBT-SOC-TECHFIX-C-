using System;
using System.Data;
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
                    LoadProductDetails();
                }
            }
        }

        private void LoadProductDetails()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

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
                    
                }
                conn.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string imageName = null;

                // Handle file upload
                if (fileUploadImage.HasFile)
                {
                    imageName = System.IO.Path.GetFileName(fileUploadImage.FileName);
                    fileUploadImage.SaveAs(Server.MapPath("~/img/") + imageName);
                }

                SqlCommand cmd = new SqlCommand("UPDATE items SET item_name = @item_name, description = @description, price = @price" +
                    (imageName != null ? ", image_name = @image_name" : "") + " WHERE item_id = @item_id", conn);

                cmd.Parameters.AddWithValue("@item_name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                if (imageName != null)
                {
                    cmd.Parameters.AddWithValue("@image_name", imageName);
                }
                cmd.Parameters.AddWithValue("@item_id", itemId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                lblMessage.Text = "Product updated successfully!";
            }
        }
    }
}
