namespace SocietyManagementSystem
{
    partial class AddEventForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAdd;
        private TextBox txtEventName;
        private TextBox txtEventDescription;
        private TextBox txtEventLocation;
        private Label lblEventName;
        private Label lblEventDesc;
        private Label lblEventLocation;
        private Label lblEventDate;
        private DateTimePicker dateTimePickerEventDate;

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtEventDescription = new System.Windows.Forms.TextBox();
            this.txtEventLocation = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblEventDesc = new System.Windows.Forms.Label();
            this.lblEventLocation = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(175, 300);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 41);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(12, 40);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(20, 20);
            this.lblEventName.TabIndex = 2;
            this.lblEventName.Text = "Event Name:";
            // 
            // lblEventDesc
            // 
            this.lblEventDesc.AutoSize = true;
            this.lblEventDesc.Location = new System.Drawing.Point(12, 90);
            this.lblEventDesc.Name = "lblEventDesc";
            this.lblEventDesc.Size = new System.Drawing.Size(20, 20);
            this.lblEventDesc.TabIndex = 3;
            this.lblEventDesc.Text = "Event Description:";
            // 
            // lblEventLocationb 
            // 
            this.lblEventLocation.AutoSize = true;
            this.lblEventLocation.Location = new System.Drawing.Point(12, 170);
            this.lblEventLocation.Name = "lblEventLocation";
            this.lblEventLocation.Size = new System.Drawing.Size(20, 20);
            this.lblEventLocation.TabIndex = 4;
            this.lblEventLocation.Text = "Event Location:";
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Location = new System.Drawing.Point(12, 220);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(85, 30);
            this.lblEventDate.TabIndex = 5;
            this.lblEventDate.Text = "Event Date:";
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(140, 40);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(200, 30);
            this.txtEventName.TabIndex = 6;
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Location = new System.Drawing.Point(140, 90);
            this.txtEventDescription.Multiline = true;
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.Size = new System.Drawing.Size(200, 60);
            this.txtEventDescription.TabIndex = 7;
            // 
            // txtEventLocation
            // 
            this.txtEventLocation.Location = new System.Drawing.Point(140, 170);
            this.txtEventLocation.Name = "txtEventLocation";
            this.txtEventLocation.Size = new System.Drawing.Size(150, 30);
            this.txtEventLocation.TabIndex = 8;
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(140, 220);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(230, 30);
            this.dateTimePickerEventDate.TabIndex = 9;

            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.dateTimePickerEventDate);
            this.Controls.Add(this.txtEventDescription);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.txtEventLocation);
            this.Controls.Add(this.lblEventDate);
            this.Controls.Add(this.lblEventLocation);
            this.Controls.Add(this.lblEventDesc);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            this.Load += new System.EventHandler(this.AddEventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
