using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class appo : Form
    {
        public appo()
        {
            InitializeComponent();
        }

        private void appo_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            // Connection string for techfixdb database
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=techfixdb; Integrated Security=True;";

            // SQL query to fetch appointment data
            string query = "SELECT AppointmentID, FullName, Email, Phone, Message, AppointmentDate FROM Appointment";

            // Create a DataTable to hold the data
            DataTable appointmentTable = new DataTable();

            // Connect to the database and retrieve data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(appointmentTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                    return;
                }
            }

            // Create and configure the DataGridView if not added in designer
            DataGridView dataGridView = new DataGridView
            {
                DataSource = appointmentTable,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = System.Drawing.Color.Black,
                ForeColor = System.Drawing.SystemColors.ButtonHighlight,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.Gray,
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.Black,
                    ForeColor = System.Drawing.Color.White
                }
            };

            // Clear previous controls in TableLayoutPanel to avoid duplication
            tableLayoutPanel1.Controls.Clear();

            // Add the DataGridView to the TableLayoutPanel and span across all columns
            tableLayoutPanel1.Controls.Add(dataGridView, 0, 0);
            tableLayoutPanel1.SetColumnSpan(dataGridView, tableLayoutPanel1.ColumnCount);  // Span across all columns

            // Adjust TableLayoutPanel's row styles to fit DataGridView properly
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            customer_page customer = new customer_page();
            customer.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            customer_page customer = new customer_page();
            customer.Show();
            this.Hide();
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

        private void pictureBox3_Click(object sender, EventArgs e)
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
