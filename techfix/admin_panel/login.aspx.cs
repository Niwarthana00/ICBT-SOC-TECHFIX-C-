using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace techfix.admin_panel
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Role, Email FROM UserRole WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            string userEmail = reader["Email"].ToString();

                            if (role == "Admin")
                            {
                                Response.Redirect("dashboard.aspx");
                            }
                            else if (role == "Supplier" && userEmail == "supplier1@gmail.com")
                            {
                                Response.Redirect("../supplier1/dashboard.aspx");
                            }
                            else if (role == "Supplier" && userEmail == "supplier2@gmail.com")
                            {
                                Response.Redirect("../supplier2/dashboard.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "User role or email not recognized.";
                                lblMessage.Visible = true;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid email or password.";
                            lblMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.Visible = true;
            }
        }
    }
}
