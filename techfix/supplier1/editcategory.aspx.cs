using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.supplier1
{
    public partial class editcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoryId;
                if (int.TryParse(Request.QueryString["id"], out categoryId))
                {
                    LoadCategoryData(categoryId);
                }
                else
                {
                    // Handle case where ID is not valid
                    Response.Redirect("showcategory.aspx?error=invalid");
                }
            }
        }

        private void LoadCategoryData(int categoryId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT category_name FROM s2category WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCategoryName.Text = reader["category_name"].ToString();
                }
                else
                {
                    Response.Redirect("showcategory.aspx?error=notfound");
                }
                conn.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId;
            if (int.TryParse(Request.QueryString["id"], out categoryId))
            {
                string newCategoryName = txtCategoryName.Text.Trim();
                UpdateCategory(categoryId, newCategoryName);
            }
            else
            {
                lblMessage.Text = "Invalid category ID.";
            }
        }

        private void UpdateCategory(int categoryId, string categoryName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE category SET category_name = @categoryName WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    // Redirect back to the addcategory page with a success message
                    Response.Redirect("showcategory.aspx?update=success");
                }
                else
                {
                    lblMessage.Text = "Update failed. Please try again.";
                }
            }
        }
    }
}
