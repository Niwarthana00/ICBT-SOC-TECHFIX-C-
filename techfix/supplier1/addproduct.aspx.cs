using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.supplier1
{
    public partial class addproduct : System.Web.UI.Page
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
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "SELECT ID, category_name FROM supplier1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ddlCategory.DataSource = reader;
                ddlCategory.DataTextField = "category_name";
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataBind();
            }

            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select a Category", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            string price = txtPrice.Text.Trim();
            string description = txtDescription.Text.Trim();
            string categoryId = ddlCategory.SelectedValue;
            string quantity = txtQuantity.Text.Trim();
            string imageUrl = txtImageUrl.Text.Trim(); // Get the URL from the text box

            if (string.IsNullOrEmpty(imageUrl))
            {
                lblMessage.Text = "Please provide a valid image URL.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            string query = "INSERT INTO s1product (product_name, image, price, description, category_id, qty) VALUES (@productName, @image, @price, @description, @categoryId, @quantity)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@image", imageUrl);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.Parameters.AddWithValue("@quantity", quantity);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    lblMessage.Text = "Product saved successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    // Clear the form fields
                    txtProductName.Text = "";
                    txtPrice.Text = "";
                    txtDescription.Text = "";
                    ddlCategory.SelectedIndex = 0;
                    txtQuantity.Text = "";
                    txtImageUrl.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }
    }
}
