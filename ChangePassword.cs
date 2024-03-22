using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class ChangePassword : Form
    {
        private string connectionString = GlobalConfig.ConnectionString;

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the current password matches the one in the database
                    var cmd = new MySqlCommand("SELECT `password` FROM users WHERE user_id = @UserId", connection);
                    cmd.Parameters.AddWithValue("@UserId", SessionManager.GetInstance().GetUserId());

                    var currentPasswordInDB = (string)cmd.ExecuteScalar();

                    // Directly comparing the plain text passwords (Not recommended for production)
                    if (currentPasswordInDB != txtCurrentPassword.Text)
                    {
                        MessageBox.Show("The current password is incorrect.");
                        return;
                    }

                    // Update the password in the database to the new password (also in plain text)
                    cmd = new MySqlCommand("UPDATE users SET `password` = @NewPassword WHERE user_id = @UserId", connection);
                    cmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text);
                    cmd.Parameters.AddWithValue("@UserId", SessionManager.GetInstance().GetUserId());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Password changed successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password change failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
