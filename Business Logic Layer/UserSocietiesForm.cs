using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class UserSocietiesForm : Form
    {
        private int _currentUserId;
        private GetData data = new GetData();

        public UserSocietiesForm(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;

            // Ensure the ListView is set to show details.
            lvSocieties.View = View.Details;

            // Add columns to lvSocieties
            lvSocieties.Columns.Add("Society Name", 150);
            lvSocieties.Columns.Add("Role", 100);

            this.Load += new System.EventHandler(this.UserSocietiesForm_Load);
        }

        // This method will populate the ListView when the form loads.
        private void UserSocietiesForm_Load(object sender, EventArgs e)
        {
            LoadUserSocieties();
        }

        // Populating the ListView with the societies that the user has joined.
        private void LoadUserSocieties()
        {
            // Clear the ListView
            lvSocieties.Items.Clear();

            // Use data access layer method to retrieve user societies
            UsersSocietiesData socitiesData = data.GetAllUserSocieties(_currentUserId);

            if (socitiesData != null)
            {
                foreach (var s in socitiesData.Societies)
                {
                    ListViewItem item = new ListViewItem(s.SocietyName);
                    item.SubItems.Add(s.RoleName);
                    item.Tag = s.SocietyID;
                    lvSocieties.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load user societies.");
            }
        }

        // Event handler for when a society is selected from the ListView.
        private void lvSocieties_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic to handle the event when the selection changes.
            // Typically, you would enable or disable certain buttons based on the selection.
        }

        // Event handler for when the 'Details' button is clicked.
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (lvSocieties.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a society to view details.");
                return;
            }

            // Retrieve the selected society's ID from the Tag property
            int selectedSocietyId = Convert.ToInt32(lvSocieties.SelectedItems[0].Tag);

            // Instantiate the SocietyDetails form with the selected society's ID
            var societyDetailsForm = new SocietyDetails(selectedSocietyId);
            societyDetailsForm.Show();
        }
    }
}
