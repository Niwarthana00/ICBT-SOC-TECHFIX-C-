using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.supplier2
{
    public partial class showproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "SELECT id, product_name, image, price, description, qty FROM s2product";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("FullImagePath", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["FullImagePath"] = row["image"];
                    }

                    ProductGridView.DataSource = dt;
                    ProductGridView.DataBind();
                }
            }
        }

        protected void ProductGridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                // Redirect to editproduct.aspx with the selected product ID
                int productId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"editproduct.aspx?id={productId}");
            }
            else if (e.CommandName == "DeleteProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                DeleteProduct(productId);
                LoadProducts(); // Reload products to refresh the GridView
            }
        }

        private void DeleteProduct(int productId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "DELETE FROM s2product WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", productId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
