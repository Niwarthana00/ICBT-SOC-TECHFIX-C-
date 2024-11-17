using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.supplier1
{
    public partial class addcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only initialize the page; no specific code needed for Page_Load
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();

            if (!string.IsNullOrEmpty(categoryName))
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

                // SQL command to insert new category
                string query = "INSERT INTO supplier1 (category_name) VALUES (@categoryName)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryName", categoryName);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        lblMessage.Text = "Category saved successfully!";
                        lblMessage.Visible = true;

                        txtCategoryName.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Visible = true;
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please enter a category name.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }
    }
}
