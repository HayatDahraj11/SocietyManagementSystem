using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class JoinSociety : Form
    {
        public JoinSociety()
        {
            InitializeComponent();
        }

        private void JoinSociety_Load(object sender, EventArgs e)
        {
            string connectionString = GlobalConfig.ConnectionString;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT society_id, name FROM societies WHERE society_id NOT IN (SELECT society_id FROM society_members WHERE user_id = @userId)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", SessionManager.GetInstance().GetUserId());
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int societyId = reader.GetInt32(0);
                            string societyName = reader.GetString(1);
                            ListViewItem item = new ListViewItem(societyName);
                            item.Tag = societyId;
                            lvSocieties.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (lvSocieties.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSocieties.SelectedItems[0];
                int societyId = (int)selectedItem.Tag;

                string connectionString = GlobalConfig.ConnectionString;
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO society_members (user_id, society_id, role_id, join_date) VALUES (@user_id, @society_id, 2, CURDATE());";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@user_id", SessionManager.GetInstance().GetUserId());
                        cmd.Parameters.AddWithValue("@society_id", societyId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("You have successfully joined the society.");
            }
            else
            {
                MessageBox.Show("Please select a society to join.");
            }

            // Refresh the list view
            lvSocieties.Items.Clear();
            JoinSociety_Load(sender, e);
        }
    }
}
