using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class SocietyDetails : Form
    {
        private int societyId;
        private GetData getData = new GetData();

        public SocietyDetails(int societyId)
        {
            this.societyId = societyId;
            InitializeComponent();
            LoadSocietyDetails();
        }

        private void LoadSocietyDetails()
        {
            SocietyDetailsData detailsData = getData.GetSocietyDetails(societyId);

            if (detailsData != null)
            {
                lblSocietyName.Text = $"Society Name: {detailsData.Name}";
                lblDescription.Text = $"Description: {detailsData.Description}";
                lblStatus.Text = $"Status: {detailsData.Status}";
                lblCreationDate.Text = $"Creation Date: {detailsData.CreationDate.ToShortDateString()}";
                lblFounder.Text = $"Founder: {detailsData.Founder}";
                lblMentor.Text = $"Mentor: {detailsData.Mentor}";

                // Load members
                lvMembers.Items.Clear(); // Clear existing items before adding new ones
                foreach (var member in detailsData.Members)
                {
                    ListViewItem item = new ListViewItem(new[] {
                member.FullName,
                member.Role
            });
                    lvMembers.Items.Add(item);
                }

                // Load events
                lvEvents.Items.Clear(); // Clear existing items before adding new ones
                List<EventData> events = getData.GetEventsForSociety(societyId); // Assuming a method to retrieve events for the society from the database
                foreach (var eventData in events)
                {
                    ListViewItem item = new ListViewItem(new[] {
                eventData.Name,
                eventData.Description,
                eventData.EventDate.ToShortDateString() // Assuming EventDate is of type DateTime
            });
                    lvEvents.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load society details.");
            }
        }


        private void lvMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
