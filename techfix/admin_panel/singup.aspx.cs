



using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class singup : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = ddlRole.SelectedValue;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            // Connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserRole (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, @Role)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Ideally, hash this password
                    cmd.Parameters.AddWithValue("@Role", role);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Registration successful! Redirecting to login...";

                        // Redirect to login.aspx after 2 seconds
                        Response.AddHeader("REFRESH", "2;URL=login.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}
