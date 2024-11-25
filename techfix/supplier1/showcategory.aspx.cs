using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace techfix.supplier2
{
    public partial class showcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryGrid();
            }
        }

        private void BindCategoryGrid()
        {
            // Retrieve the connection string from Web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            // SQL query to retrieve category data
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, category_name FROM s2category", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                da.Fill(dt);
                conn.Close();

                // Bind the data to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Convert the CommandArgument to an integer to retrieve the category ID
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Console.WriteLine("Category ID: " + categoryId);


                // Redirect to editcategory.aspx with the category ID as a query parameter
                Response.Redirect("editcategory.aspx?id=" + categoryId);

            }
            else if (e.CommandName == "Delete")
            {
                // Convert the CommandArgument to an integer to retrieve the category ID
                int categoryId = Convert.ToInt32(e.CommandArgument);

                // Delete the selected category
                DeleteCategory(categoryId);

                // Re-bind the grid to refresh data
                BindCategoryGrid();

                // Display the success modal after deletion
                ClientScript.RegisterStartupScript(this.GetType(), "ShowSuccessModal", "showSuccessModal();", true);
            }
        }

        private void DeleteCategory(int categoryId)
        {
            // Retrieve the connection string from Web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            // SQL query to delete the category
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM s2category WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                cmd.ExecuteNonQuery(); // Execute the delete command
                conn.Close();
            }
        }
    }
}
