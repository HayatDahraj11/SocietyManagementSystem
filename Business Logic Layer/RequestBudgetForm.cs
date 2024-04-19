using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class RequestBudgetForm : Form
    {
        private int societyId;
        private int userId;
        private int eventId;
        private GetData getData = new GetData();

        public RequestBudgetForm(int societyId, int userId, int eventId)
        {
            this.societyId = societyId;
            this.userId = userId;
            this.eventId = eventId;

            InitializeComponent();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;

            if (description.Length > 0)
            {
                if (getData.RequestBudget(this.societyId, this.userId, description, this.eventId))
                {
                    MessageBox.Show("Budget request sent.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to send budget request.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a description.");
            }
        }

    }
}
