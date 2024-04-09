using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class ManageSocieties : Form
    {
        private GetData getData = new GetData();

        public ManageSocieties()
        {
            InitializeComponent();
        }

        private void ManageSocieties_Load(object sender, EventArgs e)
        {
            // Check if there are any societies pending approval
            int pendingCount = getData.GetPendingSocietiesCount();
            if (pendingCount == 0)
            {
                MessageBox.Show("No societies pending approval.");
                this.Close();
                return;
            }

            //Clear the DataGridView
            societiesGrid.Rows.Clear();
            societiesGrid.Columns.Clear();

            // Set up the DataGridView
            societiesGrid.Columns.Add("SocietyName", "Society Name");
            societiesGrid.Columns.Add("SocietyDescription", "Society Description");
            societiesGrid.Columns.Add("Status", "Status");

            // Add Accept button column
            DataGridViewButtonColumn acceptButton = new DataGridViewButtonColumn();
            acceptButton.Name = "AcceptButton";
            acceptButton.Text = "Accept";
            acceptButton.UseColumnTextForButtonValue = true;
            societiesGrid.Columns.Add(acceptButton);

            // Add Reject button column
            DataGridViewButtonColumn rejectButton = new DataGridViewButtonColumn();
            rejectButton.Name = "RejectButton";
            rejectButton.Text = "Reject";
            rejectButton.UseColumnTextForButtonValue = true;
            societiesGrid.Columns.Add(rejectButton);



            // Load pending societies into the DataGridView
            getData.LoadPendingSocietiesIntoGrid(societiesGrid);
        }

        private void societiesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle button clicks in the DataGridView
            getData.HandleSocietyAction(sender, e, societiesGrid);

            // Refresh the Dashboard
            Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
            dashboard.RefreshSocieties();

        }
    }
}
