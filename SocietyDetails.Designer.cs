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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Society Details";
            this.ClientSize = new System.Drawing.Size(800, 600); // Adjust size as needed

            // Initialize lblSocietyName
            this.lblSocietyName = new System.Windows.Forms.Label();
            this.lblSocietyName.AutoSize = true;
            this.lblSocietyName.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(this.lblSocietyName); // Add to form

            // Initialize lblDescription
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.Controls.Add(this.lblDescription); // Add to form

            // Initialize lblStatus
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 80);
            this.Controls.Add(this.lblStatus); // Add to form

            // Initialize lblCreationDate
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(20, 110);
            this.Controls.Add(this.lblCreationDate); // Add to form

            // Initialize lblFounder
            this.lblFounder = new System.Windows.Forms.Label();
            this.lblFounder.AutoSize = true;
            this.lblFounder.Location = new System.Drawing.Point(20, 140);
            this.Controls.Add(this.lblFounder); // Add to form

            // Initialize lblMentor
            this.lblMentor = new System.Windows.Forms.Label();
            this.lblMentor.AutoSize = true;
            this.lblMentor.Location = new System.Drawing.Point(20, 170);
            this.Controls.Add(this.lblMentor); // Add to form

            // Initialize lvMembers
            this.lvMembers = new System.Windows.Forms.ListView();
            this.lvMembers.View = System.Windows.Forms.View.Details;
            this.lvMembers.Columns.Add("Member Name", -2, HorizontalAlignment.Left);
            this.lvMembers.Columns.Add("Role", -2, HorizontalAlignment.Left);
            this.lvMembers.Location = new System.Drawing.Point(20, 200); // Adjust as needed
            this.lvMembers.Size = new System.Drawing.Size(760, 200); // Adjust as needed
            this.Controls.Add(this.lvMembers); // Add to form

            this.ResumeLayout(false);
        }

    }
}
