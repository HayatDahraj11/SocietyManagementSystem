using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class RegistrationForm : Form
    {
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
            DateTime joinDate = this.joinDatePicker.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || this.userTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            string connectionString = "server=localhost;database=sms;uid=root;pwd=$Zaib524719;";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO users (name, username, email, password, user_type, join_date) VALUES (@name, @username, @email, @password, @userType, @joinDate)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@userType", userType);
                        command.Parameters.AddWithValue("@joinDate", joinDate);

                        command.ExecuteNonQuery();
                        MessageBox.Show("User registered successfully.");

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
