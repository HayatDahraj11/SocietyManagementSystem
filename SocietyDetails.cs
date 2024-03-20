using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class SocietyDetails : Form
    {
        private int societyId;
        string connectionString = GlobalConfig.ConnectionString;

        public SocietyDetails(int societyId)
        {
            this.societyId = societyId;
            InitializeComponent();
            LoadSocietyDetails();
        }

        private void LoadSocietyDetails()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Load basic society info
                    var cmd = new MySqlCommand("SELECT s.*, u.full_name AS founder, m.full_name AS mentor FROM societies s LEFT JOIN users u ON s.founder_id = u.user_id LEFT JOIN users m ON s.mentor_id = m.user_id WHERE s.society_id = @societyId", connection);
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblSocietyName.Text = $"Society Name: {reader["name"]}";
                            lblDescription.Text = $"Description: {reader["description"]}";
                            lblStatus.Text = $"Status: {reader["status"]}";
                            lblCreationDate.Text = $"Creation Date: {reader.GetDateTime("creation_date").ToShortDateString()}";
                            lblFounder.Text = $"Founder: {reader["founder"]}";
                            lblMentor.Text = $"Mentor: {reader["mentor"]}";
                        }
                    }

                    // Load members
                    cmd = new MySqlCommand("SELECT u.full_name, sm.role FROM society_members sm JOIN users u ON sm.user_id = u.user_id WHERE sm.society_id = @societyId", connection);
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        lvMembers.Items.Clear(); // Clear existing items before adding new ones

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(new[] {
                                reader["full_name"].ToString(),
                                reader["role"].ToString()
                            });
                            lvMembers.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load society details: {ex.Message}");
                }
            }
        }

        private void lvMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
