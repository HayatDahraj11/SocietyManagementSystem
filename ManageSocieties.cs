using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class ManageSocieties : Form
    {

        public ManageSocieties()
        {
            InitializeComponent();
        }

        private void ManageSocieties_Load(object sender, EventArgs e)
        {

            // Get Societies count with status 'Pending', if zero then show message
            using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT COUNT(*) FROM societies WHERE status = 'Pending'", connection);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show("No societies pending approval.");
                    //close the form
                    this.Close();
                    return;
                }
            }

            // Add columns for society details and actions
            societiesGrid.Columns.Add("SocietyName", "Society Name");
            societiesGrid.Columns.Add("SocietyDescription", "Society Description");
            societiesGrid.Columns.Add("Status", "Status");

            using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT name, description, status FROM societies WHERE status = 'Pending'", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int rowIndex = societiesGrid.Rows.Add();
                        DataGridViewRow row = societiesGrid.Rows[rowIndex];

                        // Set the society details
                        row.Cells["SocietyName"].Value = reader["name"].ToString();
                        row.Cells["SocietyDescription"].Value = reader["description"].ToString();
                        row.Cells["Status"].Value = reader["status"].ToString();

                        // Add buttons to accept or reject the society
                        DataGridViewButtonColumn acceptButton = new DataGridViewButtonColumn();
                        acceptButton.Name = "AcceptButton";
                        acceptButton.Text = "Accept";
                        acceptButton.UseColumnTextForButtonValue = true;
                        societiesGrid.Columns.Add(acceptButton);

                        DataGridViewButtonColumn rejectButton = new DataGridViewButtonColumn();
                        rejectButton.Name = "RejectButton";
                        rejectButton.Text = "Reject";
                        rejectButton.UseColumnTextForButtonValue = true;
                        societiesGrid.Columns.Add(rejectButton);

                        row.Cells["AcceptButton"].Value = "Accept";
                        row.Cells["RejectButton"].Value = "Reject";

                    }
                }
            }
        }

        private void societiesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the button clicked is the Accept button
            if (e.ColumnIndex == societiesGrid.Columns["AcceptButton"].Index)
            {
                // Get the society name
                string societyName = societiesGrid.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();

                // Update the status of the society to 'Approved' and set the mentor name
                using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(@"UPDATE societies SET status = 'Approved', mentor_id = @mentor_id WHERE name = @name", connection);
                    cmd.Parameters.AddWithValue("@name", societyName);
                    cmd.Parameters.AddWithValue("@mentor_id", SessionManager.GetInstance().GetUserId());
                    cmd.ExecuteNonQuery();
                }

                // Refresh the grid
                societiesGrid.Rows.Clear();
                ManageSocieties_Load(sender, e);

                // Refresh the societies list in the main form
                Dashboard.GetInstance().RefreshSocieties();
            }
            // Check if the button clicked is the Reject button
            else if (e.ColumnIndex == societiesGrid.Columns["RejectButton"].Index)
            {
                // Get the society name
                string societyName = societiesGrid.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();

                // Update the status of the society to 'Rejected'
                using (var connection = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(@"UPDATE societies SET status = 'Rejected' WHERE name = @name", connection);
                    cmd.Parameters.AddWithValue("@name", societyName);
                    cmd.ExecuteNonQuery();
                }

                // Refresh the grid
                societiesGrid.Rows.Clear();
                ManageSocieties_Load(sender, e);

                // Refresh the societies list in the main form
                Dashboard.GetInstance().RefreshSocieties();
            }
        }
    }
}
