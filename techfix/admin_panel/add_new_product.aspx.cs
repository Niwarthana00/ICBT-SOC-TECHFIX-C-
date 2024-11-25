using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class addnew : System.Web.UI.Page
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
            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, category_name FROM category", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCategory.DataSource = reader;
                ddlCategory.DataTextField = "category_name";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();

                reader.Close();
            }

            // Add a default item to the dropdown
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Get the input values
            string itemName = txtItemName.Text;
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            string description = txtDescription.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string imageName = txtImageURL.Text;

         

            // Insert the new product into the database
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO items (item_name, category_id, description, price, image_name) " +
                               "VALUES (@itemName, @categoryId, @description, @price, @imageName)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@imageName", imageName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                lblMessage.Text = "Product added successfully!";
            }
        }
    }
}
