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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("editcategory.aspx?id=" + categoryId);
            }
            else if (e.CommandName == "Delete")
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                DeleteCategory(categoryId);
                BindCategoryGrid();
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

                conn.Close();
            }

            // Display the success modal after deletion
            ClientScript.RegisterStartupScript(this.GetType(), "ShowSuccessModal", "showSuccessModal();", true);
        }

    }
}

