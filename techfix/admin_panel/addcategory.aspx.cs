using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace techfix.admin_panel
{
    public partial class addcategory : System.Web.UI.Page
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
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, category_name, image_name FROM category", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                da.Fill(dt);
                conn.Close();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get the category ID from the selected row
            int categoryId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);

            // Redirect to the edit page with the category ID
            Response.Redirect("editcategory.aspx?id=" + categoryId);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Make sure the DataKeys collection is not empty and contains the expected key
                if (GridView1.DataKeys.Count > 0 && e.RowIndex >= 0)
                {
                    // Retrieve the category ID from the DataKeys collection
                    int categoryId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                    // Proceed with the delete operation
                    DeleteCategory(categoryId);
                    // Rebind the GridView after deletion
                    BindCategoryGrid();
                }
                else
                {
                    // Handle the case where DataKeys is not populated or the row index is invalid
                    throw new InvalidOperationException("Invalid row index or DataKeys collection is empty.");
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception as needed
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        private void DeleteCategory(int categoryId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM category WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", categoryId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Display the success modal after deletion
            ClientScript.RegisterStartupScript(this.GetType(), "ShowSuccessModal", "showSuccessModal();", true);
        }
    }
}
