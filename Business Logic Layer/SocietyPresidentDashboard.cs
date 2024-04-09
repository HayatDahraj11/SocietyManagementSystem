using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class SocietyPresidentDashboard : Form
    {
        private int societyId;
        private GetData getData = new GetData();

        public SocietyPresidentDashboard(int societyId)
        {
            InitializeComponent();
            this.societyId = societyId;
            LoadMembers();
        }

        private void LoadMembers()
        {
            listViewMembers.Items.Clear();

            SocietyMembersData membersData = getData.GetSocietyMembers(societyId);

            if (membersData != null)
            {
                foreach (var member in membersData.Members)
                {
                    ListViewItem item = new ListViewItem(member.FullName);
                    item.SubItems.Add(member.Role);
                    item.Tag = member.UserId;
                    listViewMembers.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load members.");
            }
        }

        private void buttonChangeRole_Click(object sender, EventArgs e)
        {
            // Get the selected member
            if (listViewMembers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMembers.SelectedItems[0];
                int selectedMemberId = (int)selectedItem.Tag;

                ChangeMemberRoleForm form = new ChangeMemberRoleForm(societyId, selectedMemberId);
                form.ShowDialog();

                // Update the list view
                LoadMembers();
            }
        }

        private void buttonRemoveMember_Click(object sender, EventArgs e)
        {
            // Get the selected member
            if (listViewMembers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMembers.SelectedItems[0];
                int selectedMemberId = (int)selectedItem.Tag;
                if (MessageBox.Show("Are you sure you want to remove this member?", "Remove Member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (selectedMemberId == SessionManager.GetInstance().GetUserId())
                    {
                        MessageBox.Show("You cannot remove yourself from the society");
                        return;
                    }
                    getData.RemoveMemberFromSociety(societyId, selectedMemberId);

                    // Update the list view
                    LoadMembers();
                }
            }
        }
    }
}
