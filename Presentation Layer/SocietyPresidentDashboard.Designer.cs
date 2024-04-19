namespace SocietyManagementSystem
{
    partial class SocietyPresidentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewMembers;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderRole;
        private System.Windows.Forms.Button buttonChangeRole;
        private System.Windows.Forms.Button buttonRemoveMember;
        private System.Windows.Forms.ListView listViewEvents; // ListView for managing events
        private System.Windows.Forms.ColumnHeader columnHeaderEventName;
        private System.Windows.Forms.ColumnHeader columnHeaderEventDate;
        private System.Windows.Forms.Button buttonRemoveEvent; // Button for removing events
        private System.Windows.Forms.Button buttonAddEvent; // Button for adding events
        private System.Windows.Forms.Button buttonRequestBudget; // Button for adding events
        private ListView listViewBudgetRequests;
        private ColumnHeader columnHeaderBudgetEventName;
        private ColumnHeader columnHeaderBudgetStatus;
        private ColumnHeader columnHeaderBudgetDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewMembers = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonChangeRole = new System.Windows.Forms.Button();
            this.buttonRemoveMember = new System.Windows.Forms.Button();
            this.listViewEvents = new System.Windows.Forms.ListView(); // Initialized ListView for managing events
            this.columnHeaderEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRemoveEvent = new System.Windows.Forms.Button(); // Initialized button for removing events
            this.buttonAddEvent = new System.Windows.Forms.Button(); // Initialized button for adding events
            this.buttonRequestBudget = new System.Windows.Forms.Button(); // Initialized button for requesting budget
            this.listViewBudgetRequests = new System.Windows.Forms.ListView();
            this.columnHeaderBudgetEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBudgetStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBudgetDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            // 
            // listViewMembers
            // 
            this.listViewMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderRole});
            this.listViewMembers.FullRowSelect = true;
            this.listViewMembers.Location = new System.Drawing.Point(12, 12);
            this.listViewMembers.MultiSelect = false;
            this.listViewMembers.Size = new System.Drawing.Size(376, 200); // Adjusted size
            this.listViewMembers.TabIndex = 0;
            this.listViewMembers.UseCompatibleStateImageBehavior = false;
            this.listViewMembers.View = System.Windows.Forms.View.Details;
       
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 200;
            // 
            // columnHeaderRole
            // 
            this.columnHeaderRole.Text = "Role";
            this.columnHeaderRole.Width = 200;
            // 
            // buttonChangeRole
            // 
            this.buttonChangeRole.Location = new System.Drawing.Point(12, 218);
            this.buttonChangeRole.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeRole.TabIndex = 1;
            this.buttonChangeRole.Text = "Change Role";
            this.buttonChangeRole.UseVisualStyleBackColor = true;
            this.buttonChangeRole.Click += new System.EventHandler(this.buttonChangeRole_Click);
            // 
            // buttonRemoveMember
            // 
            this.buttonRemoveMember.Location = new System.Drawing.Point(118, 218);
            this.buttonRemoveMember.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveMember.TabIndex = 2;
            this.buttonRemoveMember.Text = "Remove Member";
            this.buttonRemoveMember.UseVisualStyleBackColor = true;
            this.buttonRemoveMember.Click += new System.EventHandler(this.buttonRemoveMember_Click);
            // 
            // listViewEvents
            // 
            this.listViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEventName,
            this.columnHeaderEventDate});
            this.listViewEvents.FullRowSelect = true;
            this.listViewEvents.Location = new System.Drawing.Point(424, 12); // Adjusted location
            this.listViewEvents.MultiSelect = false;
            this.listViewEvents.Size = new System.Drawing.Size(364, 200); // Adjusted size
            this.listViewEvents.TabIndex = 3; // Set tab index
            this.listViewEvents.UseCompatibleStateImageBehavior = false;
            this.listViewEvents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderEventName
            // 
            this.columnHeaderEventName.Text = "Event Name";
            this.columnHeaderEventName.Width = 200;
            // 
            // columnHeaderEventDate
            // 
            this.columnHeaderEventDate.Text = "Event Date";
            this.columnHeaderEventDate.Width = 200;
            // 
            // buttonRemoveEvent
            // 
            this.buttonRemoveEvent.Location = new System.Drawing.Point(424, 218); // Adjusted location
            this.buttonRemoveEvent.Size = new System.Drawing.Size(100, 23); // Adjusted size
            this.buttonRemoveEvent.TabIndex = 4; // Set tab index
            this.buttonRemoveEvent.Text = "Remove Event";
            this.buttonRemoveEvent.UseVisualStyleBackColor = true;
            this.buttonRemoveEvent.Click += new System.EventHandler(this.buttonRemoveEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(530, 218); // Adjusted location
            this.buttonAddEvent.Size = new System.Drawing.Size(100, 23); // Adjusted size
            this.buttonAddEvent.TabIndex = 5; // Set tab index
            this.buttonAddEvent.Text = "Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click); // Add event handler for adding events
            //
            // buttonRequestBudget
            //
            this.buttonRequestBudget.Location = new System.Drawing.Point(636, 218); // Adjusted location
            this.buttonRequestBudget.Size = new System.Drawing.Size(100, 23); // Adjusted size
            this.buttonRequestBudget.TabIndex = 6; // Set tab index
            this.buttonRequestBudget.Text = "Request Budget";
            this.buttonRequestBudget.UseVisualStyleBackColor = true;
            this.buttonRequestBudget.Click += new System.EventHandler(this.buttonRequestBudget_Click); // Add event handler for requesting budget
            // 
            // listViewBudgetRequests
            // 
            this.listViewBudgetRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBudgetEventName,
            this.columnHeaderBudgetStatus,
            this.columnHeaderBudgetDescription});
            this.listViewBudgetRequests.FullRowSelect = true;
            this.listViewBudgetRequests.Location = new System.Drawing.Point(12, 250);
            this.listViewBudgetRequests.MultiSelect = false;
            this.listViewBudgetRequests.Size = new System.Drawing.Size(650, 130); // Adjust size as needed
            this.listViewBudgetRequests.TabIndex = 7; // Set tab index
            this.listViewBudgetRequests.UseCompatibleStateImageBehavior = false;
            this.listViewBudgetRequests.View = System.Windows.Forms.View.Details;
            this.Controls.Add(this.listViewBudgetRequests); // Add the ListView to the form
            //
            // columnHeaderBudgetEventName
            //
            this.columnHeaderBudgetEventName.Text = "Event Name";
            this.columnHeaderBudgetEventName.Width = 200;
            //
            // columnHeaderBudgetStatus
            //
            this.columnHeaderBudgetStatus.Text = "Status";
            this.columnHeaderBudgetStatus.Width = 200;
            //
            // columnHeaderBudgetDescription
            //
            this.columnHeaderBudgetDescription.Text = "Description";
            this.columnHeaderBudgetDescription.Width = 200;
            // 
            // SocietyPresidentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddEvent); // Added the new button to the form
            this.Controls.Add(this.buttonRemoveEvent); // Added the new button to the form
            this.Controls.Add(this.listViewEvents); // Added the new ListView to the form
            this.Controls.Add(this.buttonRemoveMember);
            this.Controls.Add(this.buttonChangeRole);
            this.Controls.Add(this.listViewMembers);
            this.Controls.Add(this.buttonRequestBudget);
            this.Controls.Add(this.listViewBudgetRequests);
            this.Name = "SocietyPresidentDashboard";
            this.Text = "Society President Dashboard";
        }
    }
}
