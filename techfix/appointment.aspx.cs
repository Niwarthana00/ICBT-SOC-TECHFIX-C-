using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace techfix
{
    public partial class appointment : System.Web.UI.Page
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
                            cmd.Parameters.AddWithValue("@FullName", TextBox1.Text);
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
                // Your login logic here
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
                            cmd.Parameters.AddWithValue("@Password", txtLoginPassword.Text); // Hash the password in production

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Read();
                                Session["Email"] = reader["Email"].ToString(); // Set session variable
                                Session["IsLoggedIn"] = true; // Indicate user is logged in
                                Response.Redirect("home.aspx"); // Redirect to home after login
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO appointment (FullName, Email, Phone, Message) " +
                                   "VALUES (@FullName, @Email, @Phone, @Message)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Message", txtMessage.Text);

                        // Execute the query
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            // Display success message
                            Response.Write("<script>alert('Appointment successfully booked!');</script>");
                        }
                        else
                        {
                            // Display failure message
                            Response.Write("<script>alert('Appointment booking failed. Please try again.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle and display any errors
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




