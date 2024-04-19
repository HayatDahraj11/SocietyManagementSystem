using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class JoinEventsForm : Form
    {
        private GetData getData = new GetData();

        public JoinEventsForm()
        {
            InitializeComponent();
        }

        private void JoinEventsForm_Load(object sender, EventArgs e)
        {
            lvEvents.Items.Clear(); // Clear items before reloading
            foreach (var @event in getData.GetAllEvents(SessionManager.GetInstance().GetUserId()))
            {
                ListViewItem item = new ListViewItem(@event.EventName);
                item.SubItems.Add(@event.Description);
                item.SubItems.Add(@event.EventDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(@event.Location);
                item.SubItems.Add(@event.SocietyName);
                item.Tag = @event.EventId; // Store EventId in the Tag property for reference
                lvEvents.Items.Add(item);
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvEvents.SelectedItems[0];
                int eventId = (int)selectedItem.Tag; // Retrieve EventId from the Tag property

                bool success = getData.JoinEvent(SessionManager.GetInstance().GetUserId(), eventId);

                if (success)
                {
                    MessageBox.Show("You have successfully joined the event.");
                    lvEvents.Items.Clear(); // Clear items after joining
                    JoinEventsForm_Load(sender, e); // Reload items after joining
                }
                else
                {
                    MessageBox.Show("Failed to join the event. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select an event to join.");
            }
        }
    }
}
