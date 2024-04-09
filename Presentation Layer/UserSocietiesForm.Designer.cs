namespace SocietyManagementSystem
{
    partial class UserSocietiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvSocieties = new System.Windows.Forms.ListView();
            this.lblSocietiesList = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvSocieties
            // 
            this.lvSocieties.FullRowSelect = true;
            this.lvSocieties.GridLines = true;
            this.lvSocieties.Location = new System.Drawing.Point(10, 10);
            this.lvSocieties.Name = "lvSocieties";
            this.lvSocieties.Size = new System.Drawing.Size(780, 350);
            this.lvSocieties.TabIndex = 0;
            this.lvSocieties.UseCompatibleStateImageBehavior = false;
            this.lvSocieties.View = System.Windows.Forms.View.Details;
            this.lvSocieties.SelectedIndexChanged += new System.EventHandler(this.lvSocieties_SelectedIndexChanged);
            // 
            // lblSocietiesList
            // 
            this.lblSocietiesList.Location = new System.Drawing.Point(10, 370);
            this.lblSocietiesList.Name = "lblSocietiesList";
            this.lblSocietiesList.Size = new System.Drawing.Size(200, 20);
            this.lblSocietiesList.TabIndex = 1;
            this.lblSocietiesList.Text = "Societies You\'ve Joined:";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(10, 400);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(100, 30);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "View Details";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // UserSocietiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvSocieties);
            this.Controls.Add(this.lblSocietiesList);
            this.Controls.Add(this.btnDetails);
            this.Name = "UserSocietiesForm";
            this.Text = "Your Societies";
            this.Load += new System.EventHandler(this.UserSocietiesForm_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private ListView lvSocieties;
        private Label lblSocietiesList;
        private Button btnDetails;
    }
}