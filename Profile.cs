using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class Profile : Form
    {
        private string connectionString = GlobalConfig.ConnectionString;

        public Profile()
        {
            InitializeComponent();
            PopulateProfileDetails();
            PopulateSocietiesList();
            PopulateEventsList();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Update the user's username, email, and full name
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE users SET username = @Username, email = @Email, full_name = @FullName WHERE user_id = @UserId", connection);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@UserId", SessionManager.GetInstance().GetUserId());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Profile updated successfully.");
                    // Reload the session to reflect the changes
                    SessionManager.GetInstance().ReloadSession();
                    PopulateProfileDetails();
                }
                else
                {
                    MessageBox.Show("An error occurred. Profile not updated.");
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var changePasswordForm = new ChangePassword();
            changePasswordForm.Show();
        }

        private void lvSocieties_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the selection changed event if needed
        }

        private void lvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the selection changed event if needed
        }

        private void labelSocieties_Click(object sender, EventArgs e)
        {
            // Handle the click event if needed
        }

        private void lblUserType_Click(object sender, EventArgs e)
        {
            // Handle the click event if needed
        }

        private void PopulateProfileDetails()
        {
            txtUsername.Text = SessionManager.GetInstance().GetUsername();
            txtEmail.Text = SessionManager.GetInstance().GetUserEmail();
            txtFullName.Text = SessionManager.GetInstance().GetUserFullName();
            lblUserType2.Text = SessionManager.GetInstance().GetUserType();

        }

        private void PopulateSocietiesList()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT societies.name AS SocietyName, society_members.role 
                                     FROM societies 
                                     JOIN society_members ON societies.society_id = society_members.society_id 
                                     WHERE society_members.user_id = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", SessionManager.GetInstance().GetUserId());

                using (var reader = cmd.ExecuteReader())
                {
                    lvSocieties.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["SocietyName"].ToString());
                        item.SubItems.Add(reader["role"].ToString());
                        lvSocieties.Items.Add(item);
                    }
                }
            }
        }

        private void PopulateEventsList()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT events.name AS EventName, societies.name AS SocietyName 
                                     FROM events 
                                     JOIN event_registrations ON events.event_id = event_registrations.event_id 
                                     JOIN societies ON events.society_id = societies.society_id 
                                     WHERE event_registrations.user_id = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", SessionManager.GetInstance().GetUserId());

                using (var reader = cmd.ExecuteReader())
                {
                    lvEvents.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["EventName"].ToString());
                        item.SubItems.Add(reader["SocietyName"].ToString());
                        lvEvents.Items.Add(item);
                    }
                }
            }
        }

    }
}
