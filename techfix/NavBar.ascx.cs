using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace techfix
{
    public partial class NavBar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in and toggle visibility of buttons accordingly
            bool isLoggedIn = Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"];
            btnLogout.Visible = isLoggedIn; // Show logout button if user is logged in
        }

        // Method to handle the registration process
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Users (FullName, Address, ContactNumber, Email, Password) VALUES (@FullName, @Address, @Contact, @Email, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); 

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Registration successful!'); window.onload = function() { $('#loginModal').modal('show'); }; </script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Registration failed. No rows affected.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Method to handle the login process
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtLoginEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtLoginPassword.Text); 

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string userType = reader["usertype"] != DBNull.Value ? reader["usertype"].ToString() : string.Empty;

                            if (string.IsNullOrEmpty(userType))
                            {
                                Response.Write("<script>alert('No user type assigned for this account.');</script>");
                                return;
                            }

                            Session["Email"] = reader["Email"].ToString(); //  session variable
                            Session["IsLoggedIn"] = true; // Indicate user is logged in

                            // Redirect based on usertype
                            switch (userType.ToLower())
                            {
                                case "customer":
                                    Response.Redirect("home.aspx");
                                    break;
                                case "supplier":
                                    Response.Redirect("supplier_main.aspx");
                                    break;
                                case "admin":
                                    Response.Redirect("admin.aspx");
                                    break;
                                default:
                                    Response.Write("<script>alert('No valid user type found.');</script>");
                                    break;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid email or password.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }


        // Method to handle the logout process
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Clear the session
            Response.Redirect("home.aspx"); // Redirect to home after logout
        }
    }
}
