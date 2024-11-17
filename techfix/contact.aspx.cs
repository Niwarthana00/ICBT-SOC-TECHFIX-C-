using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;

namespace techfix
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in and toggle visibility of buttons accordingly
            bool isLoggedIn = Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"];
            btnLogout.Visible = isLoggedIn; // Show logout button if user is logged in
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Your registration logic here
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
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Hash the password in production

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
            string name = txtName.Text;
            string email = txtEmail.Text;
            string subject = txtSubject.Text;
            string message = txtMessage.Text;

            // SQL insert logic
            string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Contacts (Name, Email, Subject, Message) VALUES (@Name, @Email, @Subject, @Message)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Subject", subject);
                    command.Parameters.AddWithValue("@Message", message);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Display success message
                        Response.Write("<script>alert('Message saved successfully!');</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Database Error: " + ex.Message + "');</script>");
                        return; // Exit if there's a database error
                    }
                }
            }

            // Optionally, you can clear the input fields after submission
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Clear the session
            Response.Redirect("home.aspx"); // Redirect to home after logout
        }
    }
}
