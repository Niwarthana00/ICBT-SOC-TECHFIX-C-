using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using static techfix.Cart;

namespace techfix
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrderSummary();
            }
        }

        private void BindOrderSummary()
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;

            if (cartItems != null && cartItems.Count > 0)
            {
                lvOrderSummary.DataSource = cartItems;
                lvOrderSummary.DataBind();

                decimal grandTotal = cartItems.Sum(item => item.TotalPrice);
                grandTotalSummary.Text = "RS. " + grandTotal.ToString("0.00");
            }
            else
            {
                lvOrderSummary.DataSource = null;
                lvOrderSummary.DataBind();

                grandTotalSummary.Text = "RS. 0.00";
            }
        }

        protected void PayNow_Click(object sender, EventArgs e)
        {
            string customerName = txtFullName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;
            decimal grandTotal = cartItems.Sum(item => item.TotalPrice);

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(customerName))
                errors.Add("Customer Name is required");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                errors.Add("Phone Number is required");
            if (string.IsNullOrWhiteSpace(address))
                errors.Add("Address is required");

            if (errors.Any())
            {
                string errorMessages = string.Join("', '", errors);
                string script = $@"
                toastr.options = {{
                    'closeButton': true,
                    'progressBar': true,
                    'newestOnTop': false,
                    'positionClass': 'toast-top-right',
                    'preventDuplicates': true,
                    'showDuration': '300',
                    'hideDuration': '1000',
                    'timeOut': '5000',
                    'showMethod': 'fadeIn',
                    'hideMethod': 'fadeOut'
                }};
                var errors = ['{errorMessages}'];
                errors.forEach(function(error) {{
                    toastr.error(error, 'Validation Error');
                }});";

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowToastr", script, true);
                return;
            }

            int generatedOrderId = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                for (int i = 0; i < cartItems.Count; i++)
                {
                    var item = cartItems[i];
                    SqlCommand cmd = new SqlCommand("INSERT INTO customerorder (customer_name, phone_number, address, item_name, quantity, price, order_total) OUTPUT INSERTED.orderid VALUES (@customerName, @phoneNumber, @address, @itemName, @quantity, @price, @orderTotal)", conn);

                    cmd.Parameters.AddWithValue("@customerName", customerName);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.Parameters.AddWithValue("@orderTotal", grandTotal);

                    if (i == 0)
                    {
                        generatedOrderId = (int)cmd.ExecuteScalar();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            string successScript = $@"
            toastr.success('Order placed successfully!', 'Success');";

            ScriptManager.RegisterStartupScript(this, GetType(), "ShowSuccessToastr", successScript, true);

            Session["Cart"] = null;
            BindOrderSummary();
        }

        protected void BackToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}
