using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace techfix.admin_panel
{
    public partial class s1analyze : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders(); // Load all orders by default
            }
        }

        private void LoadOrders(int? month = null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT OrderId, CustomerName, CustomerNumber, ProductId, ProductName, Quantity, Price, OrderDate " +
                               "FROM s1order";
                if (month.HasValue && month.Value > 0)
                {
                    query += " WHERE MONTH(OrderDate) = @Month";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (month.HasValue && month.Value > 0)
                    {
                        cmd.Parameters.AddWithValue("@Month", month.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMonth = int.Parse(ddlMonth.SelectedValue);
            LoadOrders(selectedMonth > 0 ? (int?)selectedMonth : null);
        }
    }
}
