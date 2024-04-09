using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class Profile : Form
    {
        private GetData getData = new GetData();

        public Profile()
        {
            InitializeComponent();
            PopulateProfileDetails();
            PopulateSocietiesList();
            PopulateEventsList();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            getData.UpdateUserProfile(SessionManager.GetInstance().GetUserId(), txtUsername.Text, txtEmail.Text, txtFullName.Text);
            PopulateProfileDetails();
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
            var userDetails = getData.GetUserProfileDetails(SessionManager.GetInstance().GetUserId());
            if (userDetails != null)
            {
                txtUsername.Text = userDetails.Username;
                txtEmail.Text = userDetails.Email;
                txtFullName.Text = userDetails.FullName;
                lblUserType2.Text = userDetails.UserType;
            }
        }

        private void PopulateSocietiesList()
        {
            var societiesList = getData.GetUser_Societies(SessionManager.GetInstance().GetUserId());
            if (societiesList != null)
            {
                foreach (var society in societiesList)
                {
                    /* ListViewItem item = new ListViewItem(new[] { "Society Name", "Role" });
lvSocieties.Items.Add(item); add like this
                     */
                    var item = new ListViewItem(society.SocietyName);
                    item.SubItems.Add(society.RoleName);
                    lvSocieties.Items.Add(item);

                }
                lvSocieties.Refresh();
            }
        }

        private void PopulateEventsList()
        {
            var eventsList = getData.GetUserEvents(SessionManager.GetInstance().GetUserId());
            if (eventsList != null)
            {
                foreach (var evnt in eventsList)
                {
                    var item = new ListViewItem(evnt.EventName);
                    item.SubItems.Add(evnt.SocietyName);
                    lvEvents.Items.Add(item);
                }
            }
        }
    }
}
