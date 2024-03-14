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
                            MessageBox.Show("Login successful.");
                            // Proceed to the main application
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
    }
}
