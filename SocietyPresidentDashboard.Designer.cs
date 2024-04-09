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
            // 
            // listViewMembers
            // 
            this.listViewMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderRole});
            this.listViewMembers.FullRowSelect = true;
            this.listViewMembers.Location = new System.Drawing.Point(12, 12);
            this.listViewMembers.MultiSelect = false;
            this.listViewMembers.Size = new System.Drawing.Size(776, 397);
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
            this.buttonChangeRole.Location = new System.Drawing.Point(12, 415);
            this.buttonChangeRole.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeRole.TabIndex = 1;
            this.buttonChangeRole.Text = "Change Role";
            this.buttonChangeRole.UseVisualStyleBackColor = true;
            this.buttonChangeRole.Click += new System.EventHandler(this.buttonChangeRole_Click);
            // 
            // buttonRemoveMember
            // 
            this.buttonRemoveMember.Location = new System.Drawing.Point(118, 415);
            this.buttonRemoveMember.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveMember.TabIndex = 2;
            this.buttonRemoveMember.Text = "Remove Member";
            this.buttonRemoveMember.UseVisualStyleBackColor = true;
            this.buttonRemoveMember.Click += new System.EventHandler(this.buttonRemoveMember_Click);
            // 
            // SocietyPresidentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRemoveMember);
            this.Controls.Add(this.buttonChangeRole);
            this.Controls.Add(this.listViewMembers);
            this.Name = "SocietyPresidentDashboard";
            this.Text = "Society President Dashboard";
        }
    }
}