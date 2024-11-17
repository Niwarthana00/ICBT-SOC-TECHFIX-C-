using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace techfix
{
    public partial class item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryId = Request.QueryString["category_id"];
                if (!string.IsNullOrEmpty(categoryId))
                {
                    LoadItems(categoryId);
                }
                else
                {
                    Response.Write("<p class='text-white'>No category selected.</p>");
                }

                // Set the login status for the client-side script
                string script = $"var isLoggedIn = {IsUserLoggedIn().ToString().ToLower()};";
                ClientScript.RegisterStartupScript(this.GetType(), "LoginStatus", script, true);
            }
        }

        private void LoadItems(string categoryId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT item_name, description, price, image_name FROM items WHERE category_id = @CategoryId", conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        BindItems(dt);
                    }
                    else
                    {
                        Response.Write("<p class='text-white'>No items found for this category.</p>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("<p class='text-white'>An error occurred while loading items. Please try again later.</p>");

                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        private void BindItems(DataTable dt)
        {
            lvItems.DataSource = dt;
            lvItems.DataBind();
        }

        private bool IsUserLoggedIn()
        {
            // Check if the user is logged in
            // This assumes you're using Session to store login state
            // Modify this if you're using a different authentication method
            return Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"];
        }
    }
}