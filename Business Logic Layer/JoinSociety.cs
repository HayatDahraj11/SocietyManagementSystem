using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class JoinSociety : Form
    {
        private GetData getData = new GetData();

        public JoinSociety()
        {
            InitializeComponent();
        }

        private void JoinSociety_Load(object sender, EventArgs e)
        {
            lvSocieties.Items.Clear(); // Clear items before reloading

            foreach (var society in getData.GetAvailableSocieties(SessionManager.GetInstance().GetUserId()))
            {
                ListViewItem item = new ListViewItem(society.Name);
                item.Tag = society.SocietyId;
                lvSocieties.Items.Add(item);
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (lvSocieties.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSocieties.SelectedItems[0];
                int societyId = (int)selectedItem.Tag;

                bool success = getData.JoinSociety(SessionManager.GetInstance().GetUserId(), societyId);

                if (success)
                {
                    MessageBox.Show("You have successfully joined the society.");
                    lvSocieties.Items.Clear(); // Clear items after joining
                    JoinSociety_Load(sender, e); // Reload items after joining
                }
                else
                {
                    MessageBox.Show("Failed to join the society. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a society to join.");
            }
        }
    }
}
