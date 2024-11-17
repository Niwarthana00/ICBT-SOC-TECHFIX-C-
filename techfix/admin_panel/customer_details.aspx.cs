using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace techfix.admin_panel
{
    public partial class customer_orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch customer data only on the first page load
                FetchCustomerData();

            }
        }

        private void FetchCustomerData()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            string query = "SELECT ID, FullName, Address, ContactNumber, Email FROM Users WHERE usertype = 'customer'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        customerTable.DataSource = dt;
                        customerTable.DataBind();
                    }
                    else
                    {
                        customerTable.DataSource = null;
                        customerTable.DataBind();
                    }
                }
            }
        }
    }
}
