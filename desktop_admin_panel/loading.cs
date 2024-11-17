using System;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    public partial class loading : Form
    {
        private Timer timer;

        public loading()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // Initialize the timer
            timer = new Timer();
            timer.Interval = 50; // Set interval in milliseconds (adjust as needed for speed)
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Increment progress bar
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1; // Increase progress by 1%
            }
            else
            {
                // Stop the timer once progress reaches 100%
                timer.Stop();
                timer.Dispose();

                // Hide the loading form
                this.Hide();

                // Load the login form
                login loginForm = new login();
                loginForm.ShowDialog(); // Use ShowDialog to keep the form active

                // Close the loading form after login form is closed
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label1 click event if needed
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Handle label2 click event if needed
        }

        private void loading_Load(object sender, EventArgs e)
        {

        }
    }
}
