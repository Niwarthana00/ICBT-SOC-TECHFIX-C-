using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class contact : Form
    {
        public contact()
        {
            InitializeComponent();
            LoadContactData();
        }

        private void LoadContactData()
        {
            // Connection string for techfixdb
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Query to fetch data from Contacts table
                    string query = "SELECT Id, Name, Email, Subject, Message, SubmittedAt FROM Contacts";

                    // Create SqlDataAdapter to fill DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Fill the data table
                    adapter.Fill(dataTable);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Format DataGridView
                    dataGridView1.Columns["Id"].HeaderText = "ID";
                    dataGridView1.Columns["Name"].HeaderText = "Name";
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["Subject"].HeaderText = "Subject";
                    dataGridView1.Columns["Message"].HeaderText = "Message";
                    dataGridView1.Columns["SubmittedAt"].HeaderText = "Submitted At";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            customer_page customer = new customer_page();
            customer.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard customer = new dashboard();
            customer.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                login loginform = new login();
                loginform.Show();
                this.Hide();
            }
        }
    }
}
