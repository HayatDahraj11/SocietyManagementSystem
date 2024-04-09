using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class RegisterSociety : Form
    {
        private GetData getData = new GetData();

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
                var result = getData.RegisterSociety(txtSocietyName.Text, txtDescription.Text, SessionManager.GetInstance().GetUserId(), DateTime.Now);

                if (result)
                {
                    MessageBox.Show("Society registered successfully.");
                    txtSocietyName.Text = "";
                    txtDescription.Text = "";
                    this.Close();

                    // Refresh the dashboard
                    Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
                    dashboard.RefreshSocieties();
                }
                else
                {
                    MessageBox.Show("Error registering society.");
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
