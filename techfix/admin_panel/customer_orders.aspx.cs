using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace techfix.admin_panel
{
    public partial class customer_orders1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerOrders();
            }
        }

        private void LoadCustomerOrders()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT orderid, customer_name, phone_number, address, item_name, quantity, price, order_total, order_date FROM customerorder";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to GridView
                    CustomerOrdersGridView.DataSource = dt;
                    CustomerOrdersGridView.DataBind();
                }
            }
        }
    }
}
