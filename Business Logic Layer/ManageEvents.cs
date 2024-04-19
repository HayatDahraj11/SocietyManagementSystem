// ManageEvents.cs
using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class ManageEvents : Form
    {
        private GetData getData = new GetData();

        public ManageEvents()
        {
            InitializeComponent();
        }

        private void ManageEvents_Load(object sender, EventArgs e)
        {
            // Check if there are any resource requests pending approval
            int pendingCount = getData.GetPendingResourceRequestsCount();
            if (pendingCount == 0)
            {
                MessageBox.Show("No resource requests pending approval.");
                this.Close();
                return;
            }

            // Clear the DataGridView
            eventsGrid.Rows.Clear();
            eventsGrid.Columns.Clear();

            // Set up the DataGridView
            eventsGrid.Columns.Add("EventName", "Event Name");
            eventsGrid.Columns.Add("SocietyName", "Society Name");
            eventsGrid.Columns.Add("ResourceName", "Resource Name");
            eventsGrid.Columns.Add("Status", "Status");

            // Add Approve button column
            DataGridViewButtonColumn approveButton = new DataGridViewButtonColumn();
            approveButton.Name = "ApproveButton";
            approveButton.Text = "Approve";
            approveButton.UseColumnTextForButtonValue = true;
            eventsGrid.Columns.Add(approveButton);

            // Add Reject button column
            DataGridViewButtonColumn rejectButton = new DataGridViewButtonColumn();
            rejectButton.Name = "RejectButton";
            rejectButton.Text = "Reject";
            rejectButton.UseColumnTextForButtonValue = true;
            eventsGrid.Columns.Add(rejectButton);

            // Load pending resource requests into the DataGridView
            getData.LoadPendingResourceRequestsIntoGrid(eventsGrid);
        }

        private void eventsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle button clicks in the DataGridView
            getData.HandleResourceRequestAction(sender, e, eventsGrid);

            // Refresh the Dashboard
            Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        }
    }
}
