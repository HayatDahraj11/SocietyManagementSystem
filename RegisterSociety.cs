using MySql.Data.MySqlClient;

namespace SocietyManagementSystem
{
    public partial class RegisterSociety : Form
    {

        private string connectionString = GlobalConfig.ConnectionString;

        public RegisterSociety()
        {
            InitializeComponent();
        }

        private void btnRegisterSociety_Click(object sender, EventArgs e)
        {
            if (txtSocietyName.Text == "" || txtDescription.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO societies (name, description, creation_date, founder_id) VALUES (@name, @description, @creation_date, @founder_id)";
                        command.Parameters.AddWithValue("@name", txtSocietyName.Text);
                        command.Parameters.AddWithValue("@description", txtDescription.Text);
                        command.Parameters.AddWithValue("@creation_date", DateTime.Now);
                        command.Parameters.AddWithValue("@founder_id", SessionManager.GetInstance().GetUserId());
                        command.ExecuteNonQuery();

                        MessageBox.Show("Society registered successfully.");
                        this.txtSocietyName.Text = "";
                        this.txtDescription.Text = "";

                        connection.Close();
                        this.Close();

                        // Refresh the dashboard
                        Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
                        dashboard.RefreshSocieties();
                    }
                }
            }
        }

        private void registerSocietyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RegisterSociety registerSociety = new RegisterSociety();
            registerSociety.Show();
        }
    }
}
