using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocietyManagementSystem
{
    public partial class UserSocietiesForm : Form
    {
        private int _currentUserId; // This should be set when the form is initialized.

        // Modify the constructor to accept the user ID.
        // private int _currentUserId;

        public UserSocietiesForm(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;

            // Ensure the ListView is set to show details.
            lvSocieties.View = View.Details;

            // Add columns to lvSocieties
            lvSocieties.Columns.Add("Society Name", 150); // Adjust the width as needed
            lvSocieties.Columns.Add("Role", 100); // Adjust the width as needed

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
            string connectionString = "server=localhost;database=sms;uid=root;pwd=hayat;";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT s.society_id, s.name, sm.role " +
                                   "FROM societies s " +
                                   "JOIN society_members sm ON s.society_id = sm.society_id " +
                                   "WHERE sm.user_id = @UserId;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", _currentUserId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var societyId = reader["society_id"].ToString();
                                var societyName = reader["name"].ToString();
                                var role = reader["role"].ToString();

                                ListViewItem item = new ListViewItem(new[] { societyName, role })
                                {
                                    Tag = societyId
                                };
                                lvSocieties.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading societies: " + ex.Message);
                }
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
