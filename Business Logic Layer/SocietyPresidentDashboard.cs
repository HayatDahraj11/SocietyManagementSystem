﻿using SocietyManagementSystem.Data_Access_Layer;

namespace SocietyManagementSystem
{
    public partial class SocietyPresidentDashboard : Form
    {
        private int societyId;
        private GetData getData = new GetData();

        public SocietyPresidentDashboard(int societyId)
        {
            InitializeComponent();
            this.societyId = societyId;
            LoadMembers();
            LoadEvents();
            LoadBudgetRequests();
        }

        private void LoadMembers()
        {
            listViewMembers.Items.Clear();

            SocietyMembersData membersData = getData.GetSocietyMembers(societyId);

            if (membersData != null)
            {
                foreach (var member in membersData.Members)
                {
                    ListViewItem item = new ListViewItem(member.FullName);
                    item.SubItems.Add(member.Role);
                    item.Tag = member.UserId;
                    listViewMembers.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load members.");
            }
        }

        private void LoadEvents()
        {
            listViewEvents.Items.Clear();

            // Use GetData method to retrieve events for the society
            List<EventData> events = getData.GetEventsForSociety(societyId);

            if (events != null)
            {
                foreach (var eventData in events)
                {
                    ListViewItem item = new ListViewItem(eventData.Name);
                    item.SubItems.Add(eventData.Description);
                    item.SubItems.Add(eventData.EventDate.ToShortDateString()); // Format date as needed
                    item.Tag = eventData.EventId; // Store event ID in the Tag property for later reference
                    listViewEvents.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load events.");
            }

        }

        // Method to load and display budget requests
        private void LoadBudgetRequests()
        {
            listViewBudgetRequests.Items.Clear();

            // Use GetData method to retrieve budget requests
            List<BudgetRequestData> budgetRequests = getData.GetBudgetRequestsForSociety(societyId);

            if (budgetRequests != null)
            {
                foreach (var budgetRequest in budgetRequests)
                {
                    ListViewItem item = new ListViewItem(budgetRequest.EventName);
                    item.SubItems.Add(budgetRequest.Status);
                    item.SubItems.Add(budgetRequest.Description);
                    listViewBudgetRequests.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to load budget requests.");
            }
        }

        private void buttonChangeRole_Click(object sender, EventArgs e)
        {
            // Get the selected member
            if (listViewMembers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMembers.SelectedItems[0];
                int selectedMemberId = (int)selectedItem.Tag;

                ChangeMemberRoleForm form = new ChangeMemberRoleForm(societyId, selectedMemberId);
                form.ShowDialog();

                // Update the list view
                LoadMembers();
            }
        }

        private void buttonRemoveMember_Click(object sender, EventArgs e)
        {
            // Get the selected member
            if (listViewMembers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMembers.SelectedItems[0];
                int selectedMemberId = (int)selectedItem.Tag;
                if (MessageBox.Show("Are you sure you want to remove this member?", "Remove Member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (selectedMemberId == SessionManager.GetInstance().GetUserId())
                    {
                        MessageBox.Show("You cannot remove yourself from the society");
                        return;
                    }
                    getData.RemoveMemberFromSociety(societyId, selectedMemberId);


                }
            }
            // Update the list view
            LoadMembers();
        }
        private void buttonRemoveEvent_Click(object sender, EventArgs e)
        {
            // Get the selected event
            if (listViewEvents.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewEvents.SelectedItems[0];
                int selectedEventId = (int)selectedItem.Tag;
                if (MessageBox.Show("Are you sure you want to remove this event?", "Remove Event", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Use GetData method to remove the event
                    getData.DeleteEvent(selectedEventId);
                }
            }
            // Update the list views
            LoadEvents();
            LoadBudgetRequests();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            // Open a form to add a new event
            AddEventForm addEventForm = new AddEventForm(societyId);
            addEventForm.ShowDialog();
            // Update the list view
            LoadEvents();
        }

        private void buttonRequestBudget_Click(object sender, EventArgs e)
        {
            // Open a form to request a budget
            if (listViewEvents.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewEvents.SelectedItems[0];
                int selectedEventId = (int)selectedItem.Tag;
                RequestBudgetForm requestBudgetForm = new RequestBudgetForm(societyId, SessionManager.GetInstance().GetUserId(), selectedEventId);
                requestBudgetForm.ShowDialog();
            }
            // Refresh Request Budgets List
            LoadBudgetRequests();

        }

        private void SocietyPresidentDashboard_Load(object sender, EventArgs e)
        {
            // Optionally, perform any actions needed when the form is loaded
        }
    }
}
