using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadSocieties();
            this.profileToolStripMenuItem.Click += ProfileToolStripMenuItem_Click;
            this.yourSocietiesToolStripMenuItem.Click += YourSocietiesToolStripMenuItem_Click;
            this.registerSocietyToolStripMenuItem.Click += RegisterSocietyToolStripMenuItem_Click;
            this.logoutToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;
        }

        private void LoadSocieties()
        {
            // Assume connectionString is defined
            string connectionString = "server=localhost;database=sms;uid=root;pwd=$Zaib524719;";
            int yOffset = 0;
            const int spacing = 10; // Space between entries

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT society_id, name, description FROM societies";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string societyid = reader["society_id"].ToString();
                                string name = reader["name"].ToString();
                                string description = reader["description"].ToString();

                                // Society Name Label
                                Label nameLabel = new Label
                                {
                                    Text = name,
                                    Font = new Font("Arial", 14, FontStyle.Bold),
                                    AutoSize = true,
                                    Location = new Point(5, yOffset),
                                    Tag = societyid
                                };
                                nameLabel.Click += (s, e) =>
                                {
                                    // Open the society details page using the society id
                                    int societyId = Convert.ToInt32(nameLabel.Tag);
                                    var societyDetails = new SocietyDetails(societyId);
                                    societyDetails.Show();
                                };
                                this.societiesPanel.Controls.Add(nameLabel);
                                yOffset += nameLabel.Height;

                                // Horizontal Line
                                Panel linePanel = new Panel
                                {
                                    Height = 2,
                                    Width = this.societiesPanel.Width - 20,
                                    BackColor = Color.Black,
                                    Location = new Point(5, yOffset)
                                };
                                this.societiesPanel.Controls.Add(linePanel);
                                yOffset += linePanel.Height + 5;

                                // Society Description Label
                                Label descriptionLabel = new Label
                                {
                                    Text = description,
                                    Font = new Font("Arial", 10),
                                    AutoSize = true,
                                    Location = new Point(5, yOffset)
                                };
                                this.societiesPanel.Controls.Add(descriptionLabel);
                                yOffset += descriptionLabel.Height + spacing;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }


        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open profile page
        }

        private void YourSocietiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open your societies page
        }

        private void RegisterSocietyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open register society form
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Handle logout
            SessionManager.GetInstance().EndUserSession();
            // Close the dashboard
            this.Close();
        }

        private void societiesListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
