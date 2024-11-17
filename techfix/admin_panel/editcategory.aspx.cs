using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class editcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoryId = Convert.ToInt32(Request.QueryString["id"]);
                LoadCategoryData(categoryId);
            }
        }

        private void LoadCategoryData(int categoryId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT category_name, image_name FROM category WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCategoryName.Text = reader["category_name"].ToString();
                    string imageName = reader["image_name"].ToString();
                    lblCurrentImage.Text = $"Current Image: <img src='../img/{imageName}' style='width:100px; height:auto;' />";
                }
                conn.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(Request.QueryString["id"]);
            string newCategoryName = txtCategoryName.Text;

            string newImageName = null;
            if (fileImage.HasFile)
            {
                string fileExtension = Path.GetExtension(fileImage.FileName);
                newImageName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Server.MapPath($"~/img/{newImageName}");
                fileImage.SaveAs(filePath);
            }

            UpdateCategory(categoryId, newCategoryName, newImageName);
        }

        private void UpdateCategory(int categoryId, string categoryName, string imageName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE category SET category_name = @categoryName" +
                               (imageName != null ? ", image_name = @imageName" : "") +
                               " WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                if (imageName != null)
                {
                    cmd.Parameters.AddWithValue("@imageName", imageName);
                }
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Redirect back to the addcategory page with a success message
            Response.Redirect("addcategory.aspx?update=success");
        }
    }
}
