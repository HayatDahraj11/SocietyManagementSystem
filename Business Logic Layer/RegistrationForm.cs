using SocietyManagementSystem.Data_Access_Layer;
using System.Text.RegularExpressions;

namespace SocietyManagementSystem
{
    public partial class RegistrationForm : Form
    {
        private GetData getData = new GetData();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string name = this.nameTextBox.Text;
            string username = this.usernameTextBox.Text;
            string email = this.emailTextBox.Text;
            string password = this.passwordTextBox.Text; // Hash this password before storing
            string userType = this.userTypeComboBox.SelectedItem.ToString();

            // Check if username already exists
            if (getData.IfExistsUser(username, email))
            {
                MessageBox.Show("Username or Email already exists.");
                return;
            }

            // Username must not have spaces or symbols
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username must not have spaces or symbols.");
                return;
            }

            // Email must be a university email
            if (!email.EndsWith("@nu.edu.pk"))
            {
                MessageBox.Show("Email must be your university email i.e. ending with @nu.edu.pk");
                return;
            }

            // Password must have at least 8 digits
            if (password.Length < 8)
            {
                MessageBox.Show("Password must have at least 8 digits.");
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || this.userTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            bool result = getData.RegisterUser(name, username, email, password, userType);

            if (result)
            {
                MessageBox.Show("User registered successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error registering user.");
            }
        }


        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}