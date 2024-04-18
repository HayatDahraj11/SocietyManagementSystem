using System;
using System.Windows.Forms;
using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class AddEventForm : Form
    {
        private int societyId;
        private GetData getData = new GetData();

        public AddEventForm(int societyId)
        {
            InitializeComponent();
            this.societyId = societyId;
            AddEventForm_Load(this, EventArgs.Empty);
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            // Retrieve event details from the text boxes
            string eventName = txtEventName.Text;
            string eventDescription = txtEventDescription.Text;
            DateTime eventDate = dateTimePickerEventDate.Value;

            // Use the GetData method to add the event
            bool success = getData.AddEvent(eventName, eventDescription, eventDate, societyId);

            if (success)
            {
                MessageBox.Show("Event added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add the event. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnJoin_Click(object sender, EventArgs e)
        {
            // Retrieve event details from the text boxes
            string eventName = txtEventName.Text;
            string eventDescription = txtEventDescription.Text;
            DateTime eventDate = dateTimePickerEventDate.Value;

            // Use the GetData method to add the event
            bool success = getData.AddEvent(eventName, eventDescription, eventDate, societyId);

            if (success)
            {
                MessageBox.Show("Event added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add the event. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            // Load events into lvSocieties
            
        }

        private void LoadEventsIntoListView()
        {
            
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
