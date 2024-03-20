using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class SocietyDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label lblSocietyName;
        private Label lblDescription;
        private Label lblStatus;
        private Label lblCreationDate;
        private Label lblFounder;
        private Label lblMentor;
        private ListView lvMembers;
        private void InitializeComponent()
        {
            lblSocietyName = new Label();
            lblDescription = new Label();
            lblStatus = new Label();
            lblCreationDate = new Label();
            lblFounder = new Label();
            lblMentor = new Label();
            lvMembers = new ListView();
            SuspendLayout();
            // 
            // lblSocietyName
            // 
            lblSocietyName.AutoSize = true;
            lblSocietyName.Location = new Point(18, 15);
            lblSocietyName.Name = "lblSocietyName";
            lblSocietyName.Size = new Size(0, 15);
            lblSocietyName.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(18, 38);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(0, 15);
            lblDescription.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(18, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 2;
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Location = new Point(18, 82);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(0, 15);
            lblCreationDate.TabIndex = 3;
            // 
            // lblFounder
            // 
            lblFounder.AutoSize = true;
            lblFounder.Location = new Point(18, 105);
            lblFounder.Name = "lblFounder";
            lblFounder.Size = new Size(0, 15);
            lblFounder.TabIndex = 4;
            // 
            // lblMentor
            // 
            lblMentor.AutoSize = true;
            lblMentor.Location = new Point(18, 128);
            lblMentor.Name = "lblMentor";
            lblMentor.Size = new Size(0, 15);
            lblMentor.TabIndex = 5;
            // 
            // lvMembers
            // 
            lvMembers.Location = new Point(18, 150);
            lvMembers.Margin = new Padding(3, 2, 3, 2);
            lvMembers.Name = "lvMembers";
            lvMembers.Size = new Size(666, 151);
            lvMembers.TabIndex = 6;
            lvMembers.UseCompatibleStateImageBehavior = false;
            lvMembers.View = View.Details;
            lvMembers.Columns.Add("Member Name", -2, HorizontalAlignment.Left);
            lvMembers.Columns.Add("Role", -2, HorizontalAlignment.Left);
            lvMembers.SelectedIndexChanged += lvMembers_SelectedIndexChanged;
            // 
            // SocietyDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(lblSocietyName);
            Controls.Add(lblDescription);
            Controls.Add(lblStatus);
            Controls.Add(lblCreationDate);
            Controls.Add(lblFounder);
            Controls.Add(lblMentor);
            Controls.Add(lvMembers);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SocietyDetails";
            Text = "Society Details";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
