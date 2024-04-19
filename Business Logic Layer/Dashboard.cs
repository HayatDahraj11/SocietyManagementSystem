using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class Dashboard : Form
    {
        private static Dashboard? instance;
        private GetData getData = new GetData();

        public static Dashboard GetInstance()
        {
            // If instance is null, or if the instance has been disposed, create a new instance
            if (instance == null || instance.IsDisposed)
            {
                instance = new Dashboard();
            }
            return instance;
        }

        private Dashboard()
        {
            InitializeComponent();
            LoadSocieties();

            // Check user's role and modify UI accordingly
            string userRole = SessionManager.GetInstance().GetUserType();
            if (userRole == "mentor")
            {
                this.registerSocietyToolStripMenuItem.Visible = false;
                this.yourSocietiesToolStripMenuItem.Visible = false;
                this.manageSocietiesToolStripMenuItem.Visible = true;
                this.manageEventsToolStripMenuItem.Visible = true;
                this.joinSocietyToolStripMenuItem.Visible = false;
            }
            else if (userRole == "student")
            {
                this.registerSocietyToolStripMenuItem.Visible = true;
                this.yourSocietiesToolStripMenuItem.Visible = true;
                this.manageSocietiesToolStripMenuItem.Visible = false;
                this.manageEventsToolStripMenuItem.Visible = false;
                this.joinSocietyToolStripMenuItem.Visible = true;


                Dictionary<int, string> userSocieties = getData.GetUserSocieties(SessionManager.GetInstance().GetUserId());
                foreach (var society in userSocieties)
                {
                    ToolStripMenuItem societyMenuItem = new ToolStripMenuItem
                    {
                        Text = society.Value,
                        Tag = society.Key
                    };
                    societyMenuItem.Click += SocietyMenuItem_Click;
                    this.menuStrip1.Items.Add(societyMenuItem);
                }
            }
        }

        public void RefreshSocieties()
        {
            this.societiesPanel.Controls.Clear();
            LoadSocieties();
        }


        private void LoadSocieties()
        {
            List<Society> societies = getData.GetApprovedSocieties();
            int yOffset = 0;
            const int spacing = 10;

            foreach (var society in societies)
            {
                Label nameLabel = new Label
                {
                    Text = society.Name,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(5, yOffset),
                    Tag = society.SocietyId
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
                    Text = society.Description,
                    Font = new Font("Arial", 10),
                    AutoSize = true,
                    Location = new Point(5, yOffset)
                };
                this.societiesPanel.Controls.Add(descriptionLabel);
                yOffset += descriptionLabel.Height + spacing;
            }
        }

        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open profile page logic here
            Profile profile = new Profile();
            profile.Show();
        }

        // This is the corrected method for opening the User Societies form
        private void YourSocietiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int currentUserId = SessionManager.GetInstance().GetUserId();
            UserSocietiesForm userSocietiesForm = new UserSocietiesForm(currentUserId);
            userSocietiesForm.Show();
        }



        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance().EndUserSession();
            this.Close();
        }



        private void registerSocietyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Implementation for opening the RegisterSociety form
            RegisterSociety registerSociety = new RegisterSociety();
            registerSociety.Show();
        }

        private void SocietyMenuItem_Click(object sender, EventArgs e)
        {
            // Open the society dashboard
            SocietyPresidentDashboard societyPresidentDashboard = new SocietyPresidentDashboard((int)((ToolStripMenuItem)sender).Tag);
            societyPresidentDashboard.Show();
        }



        private void ManageEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageEvents manageEvents = new ManageEvents();
            manageEvents.Show();

        }

        private void ManageSocietiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Manage Societies form
            ManageSocieties manageSocietiesForm = new ManageSocieties();
            manageSocietiesForm.Show();

        }

        //JoinSocietyToolStripMenuItem_Click
        private void JoinSocietyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Join Society form
            JoinSociety joinSocietyForm = new JoinSociety();
            joinSocietyForm.Show();
        }

        private void JoinEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Join Events form
            JoinEventsForm joinEventsForm = new JoinEventsForm();
            joinEventsForm.Show();
        }


    }


}
