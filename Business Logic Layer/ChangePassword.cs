using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class ChangePassword : Form
    {
        private GetData dataAccess;

        public ChangePassword()
        {
            InitializeComponent();
            dataAccess = new GetData();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                var currentPasswordInDB = dataAccess.GetPassword(SessionManager.GetInstance().GetUserId());

                // Directly comparing the plain text passwords (Not recommended for production)
                if (currentPasswordInDB != txtCurrentPassword.Text)
                {
                    MessageBox.Show("The current password is incorrect.");
                    return;
                }

                dataAccess.UpdatePassword(SessionManager.GetInstance().GetUserId(), txtNewPassword.Text);

                MessageBox.Show("Password changed successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
