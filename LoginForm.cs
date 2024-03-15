using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            loginButton.Click += new EventHandler(LoginButton_Click);
            registerButton.Click += new EventHandler(RegisterButton_Click);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=sms;uid=root;pwd=$Zaib524719;";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT COUNT(1) FROM users WHERE username=@username AND password=@password;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                        cmd.Parameters.AddWithValue("@password", passwordTextBox.Text); // Use hashed passwords in a real app
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result == 1)
                        {
                            // First Get the user id
                            query = "SELECT user_id FROM users WHERE username=@username;";
                            cmd.CommandText = query;
                            int userId = Convert.ToInt32(cmd.ExecuteScalar());
                            // Start the user session
                            SessionManager.GetInstance().StartUserSession(userId);

                            // Close the login form and open the dashboard
                            // Clear the password field
                            passwordTextBox.Text = "";
                            this.Hide();
                            var dashboard = new Dashboard();
                            dashboard.Show();
                            dashboard.FormClosed += (s, args) => this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login failed. Please check your username and password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.Show();

            Hide();

            registrationForm.FormClosed += (s, args) =>
            {
                Show();
            };
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
