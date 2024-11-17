using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class add_new_category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(categoryName.Text) && imageUpload.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(imageUpload.FileName);
                    string filePath = Server.MapPath("~/img/") + fileName;
                    imageUpload.SaveAs(filePath);

                    // Insert into database
                    string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO category (category_name, image_name) VALUES (@category_name, @image_name)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@category_name", categoryName.Text);
                        cmd.Parameters.AddWithValue("@image_name", fileName);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    lblMessage.Text = "Category added successfully!";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a category name and select an image.";
            }
        }
    }
}
