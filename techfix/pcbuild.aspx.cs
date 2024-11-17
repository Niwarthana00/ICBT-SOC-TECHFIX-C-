using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace techfix
{
    public partial class repair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            // Create a connection and command
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to select category name and image
                SqlCommand cmd = new SqlCommand("SELECT category_name, image_name,id FROM category", conn);

                // Use SqlDataAdapter to fill DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    // Open connection
                    conn.Open();
                    da.Fill(dt);

                    // Bind the DataTable to the ListView
                    lvCategories.DataSource = dt;
                    lvCategories.DataBind();
                }
                catch (SqlException ex)
                {
                    // Handle exceptions (log or display error)
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out the user
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
