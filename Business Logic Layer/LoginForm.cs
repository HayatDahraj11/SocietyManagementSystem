using SocietyManagementSystem.Data_Access_Layer;
using System.Text.RegularExpressions;

namespace SocietyManagementSystem
{
    public partial class LoginForm : Form
    {
        private GetData getData = new GetData();

        public LoginForm()
        {
            InitializeComponent();
            loginButton.Click += new EventHandler(LoginButton_Click);
            registerButton.Click += new EventHandler(RegisterButton_Click);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Username must not have spaces or symbols
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username must not have spaces or symbols.");
                return;
            }

            // Password must have at least 8 digits
            if (password.Length < 8)
            {
                MessageBox.Show("Password must have at least 8 digits.");
                return;
            }

            int loginSuccess = getData.LoginUser(username, password);

            if (loginSuccess != -1)
            {
                // Clear the password field
                passwordTextBox.Text = "";

                // Hide the login form
                this.Hide();

                //Start the session
                SessionManager.GetInstance().StartUserSession(loginSuccess);

                // Open the dashboard if it is not already open, else bring it to the front
                if (!Dashboard.GetInstance().Visible)
                {
                    Dashboard.GetInstance().Show();
                }
                else
                {
                    Dashboard.GetInstance().BringToFront();
                }

                // Show the login form again if the dashboard is closed
                Dashboard.GetInstance().FormClosed += (s, args) =>
                {
                    this.Show();
                };
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
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
