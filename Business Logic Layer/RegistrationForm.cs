using SocietyManagementSystem.Data_Access_Layer;

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
            DateTime joinDate = this.joinDatePicker.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || this.userTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            bool result = getData.RegisterUser(name, username, email, password, userType, joinDate);

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