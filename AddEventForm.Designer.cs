namespace SocietyManagementSystem
{
    partial class AddEventForm
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
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtEventDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lvSocieties
            // 
            this.lvSocieties.FullRowSelect = true;
            this.lvSocieties.GridLines = true;
            this.lvSocieties.HideSelection = false;
            this.lvSocieties.Location = new System.Drawing.Point(12, 12);
            this.lvSocieties.MultiSelect = false;
            this.lvSocieties.Name = "lvSocieties";
            this.lvSocieties.Size = new System.Drawing.Size(776, 200);
            this.lvSocieties.TabIndex = 0;
            this.lvSocieties.UseCompatibleStateImageBehavior = false;
            this.lvSocieties.View = System.Windows.Forms.View.Details;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(347, 397);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(106, 41);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "Join Society";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(12, 218);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(776, 27);
            this.txtEventName.TabIndex = 2;
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Location = new System.Drawing.Point(12, 251);
            this.txtEventDescription.Multiline = true;
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.Size = new System.Drawing.Size(776, 120);
            this.txtEventDescription.TabIndex = 3;
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(12, 377);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerEventDate.TabIndex = 4;
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePickerEventDate);
            this.Controls.Add(this.txtEventDescription);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.lvSocieties);
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            this.Load += new System.EventHandler(this.AddEventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSocieties;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.TextBox txtEventDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
    }
}
