using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocietyManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadSocieties();
            this.profileToolStripMenuItem.Click += ProfileToolStripMenuItem_Click;
            // Updated to correct event handler name
            this.yourSocietiesToolStripMenuItem.Click += YourSocietiesToolStripMenuItem_Click_1;
            this.registerSocietyToolStripMenuItem.Click += RegisterSocietyToolStripMenuItem_Click;
            this.logoutToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;
        }

        private void LoadSocieties()
        {
            string connectionString = "server=localhost;database=sms;uid=root;pwd=hayat;";
            int yOffset = 0;
            const int spacing = 10;

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
                                string societyId = reader["society_id"].ToString();
                                string name = reader["name"].ToString();
                                string description = reader["description"].ToString();

                                Label nameLabel = new Label
                                {
                                    Text = name,
                                    Font = new Font("Arial", 14, FontStyle.Bold),
                                    AutoSize = true,
                                    Location = new Point(5, yOffset),
                                    Tag = societyId
                                };
                                nameLabel.Click += (s, e) =>
                                {
                                    int id = Convert.ToInt32(nameLabel.Tag);
                                    var societyDetails = new SocietyDetails(id); // Ensure SocietyDetails form exists
                                    societyDetails.Show();
                                };
                                this.societiesPanel.Controls.Add(nameLabel);
                                yOffset += nameLabel.Height + spacing;

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
            // Open profile page logic here
        }

        // This is the corrected method for opening the User Societies form
        private void YourSocietiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int currentUserId = SessionManager.GetInstance().GetUserId();
            UserSocietiesForm userSocietiesForm = new UserSocietiesForm(currentUserId);
            userSocietiesForm.Show();
        }

        private void RegisterSocietyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open register society form logic here
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance().EndUserSession();
            this.Close();
        }
        private void profileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Implementation for what happens when the profile menu item is clicked
        }
        private void yourSocietiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Implementation for opening the UserSocietiesForm
        }

        private void societiesPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        // Removed unused event handlers to avoid confusion
    }
}
