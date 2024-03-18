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
            this.lblSocietyName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblFounder = new System.Windows.Forms.Label();
            this.lblMentor = new System.Windows.Forms.Label();
            this.lvMembers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblSocietyName
            // 
            this.lblSocietyName.AutoSize = true;
            this.lblSocietyName.Location = new System.Drawing.Point(20, 20);
            this.lblSocietyName.Name = "lblSocietyName";
            this.lblSocietyName.Size = new System.Drawing.Size(0, 20);
            this.lblSocietyName.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 20);
            this.lblDescription.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 2;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(20, 110);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(0, 20);
            this.lblCreationDate.TabIndex = 3;
            // 
            // lblFounder
            // 
            this.lblFounder.AutoSize = true;
            this.lblFounder.Location = new System.Drawing.Point(20, 140);
            this.lblFounder.Name = "lblFounder";
            this.lblFounder.Size = new System.Drawing.Size(0, 20);
            this.lblFounder.TabIndex = 4;
            // 
            // lblMentor
            // 
            this.lblMentor.AutoSize = true;
            this.lblMentor.Location = new System.Drawing.Point(20, 170);
            this.lblMentor.Name = "lblMentor";
            this.lblMentor.Size = new System.Drawing.Size(0, 20);
            this.lblMentor.TabIndex = 5;
            // 
            // lvMembers
            // 
            this.lvMembers.Location = new System.Drawing.Point(20, 200);
            this.lvMembers.Name = "lvMembers";
            this.lvMembers.Size = new System.Drawing.Size(760, 200);
            this.lvMembers.TabIndex = 6;
            this.lvMembers.UseCompatibleStateImageBehavior = false;
            this.lvMembers.View = System.Windows.Forms.View.Details;
            // 
            // SocietyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblSocietyName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCreationDate);
            this.Controls.Add(this.lblFounder);
            this.Controls.Add(this.lblMentor);
            this.Controls.Add(this.lvMembers);
            this.Name = "SocietyDetails";
            this.Text = "Society Details";
            this.Load += new System.EventHandler(this.SocietyDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
