using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class SocietyPresidentDashboard : Form
    {
        private int societyId;

        public SocietyPresidentDashboard(int societyId)
        {
            InitializeComponent();
            this.societyId = societyId;
            LoadMembers();
        }

        private void LoadMembers()
        {
            listViewMembers.Items.Clear();

            using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var query = @"
                    SELECT users.user_id, users.full_name AS name, society_roles.role_name AS role 
                    FROM society_members 
                    INNER JOIN users ON society_members.user_id = users.user_id 
                    INNER JOIN society_roles ON society_members.role_id = society_roles.role_id 
                    WHERE society_members.society_id = @societyId;";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["name"].ToString());
                            item.SubItems.Add(reader["role"].ToString());
                            item.Tag = reader["user_id"];
                            listViewMembers.Items.Add(item);
                        }
                    }
                }
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
                    RemoveMemberFromSociety(selectedMemberId);

                    // Update the list view
                    LoadMembers();
                }
            }
        }


        private void RemoveMemberFromSociety(int memberId)
        {
            using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var query = "DELETE FROM society_members WHERE society_id = @societyId AND user_id"
                    + " = @userId;";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    cmd.Parameters.AddWithValue("@userId", memberId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}