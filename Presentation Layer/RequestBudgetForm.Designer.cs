namespace SocietyManagementSystem
{
    partial class RequestBudgetForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnRequest;
        private Label lblDesc;
        private TextBox txtDescription;

        private void InitializeComponent()
        {
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(50, 175);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(100, 40);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);

            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(10, 50);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(20, 20);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Resource Description:";
           
            // txtEventDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 7;
            

            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.btnRequest);
            this.Name = "RequestBudgetForm";
            this.Text = "Request Budget";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
