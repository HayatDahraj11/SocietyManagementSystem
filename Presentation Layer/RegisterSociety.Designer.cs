namespace SocietyManagementSystem
{
    partial class RegisterSociety
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

        private void InitializeComponent()
        {
            this.lblSocietyName = new System.Windows.Forms.Label();
            this.txtSocietyName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnRegisterSociety = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblSocietyName
            this.lblSocietyName.AutoSize = true;
            this.lblSocietyName.Location = new System.Drawing.Point(20, 20);
            this.lblSocietyName.Name = "lblSocietyName";
            this.lblSocietyName.Size = new System.Drawing.Size(80, 13);
            this.lblSocietyName.TabIndex = 0;
            this.lblSocietyName.Text = "Society Name:";

            // txtSocietyName
            this.txtSocietyName.Location = new System.Drawing.Point(120, 17);
            this.txtSocietyName.Name = "txtSocietyName";
            this.txtSocietyName.Size = new System.Drawing.Size(250, 20);
            this.txtSocietyName.TabIndex = 1;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 47);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 100);
            this.txtDescription.TabIndex = 3;

            // btnRegisterSociety
            this.btnRegisterSociety.Location = new System.Drawing.Point(120, 160);
            this.btnRegisterSociety.Name = "btnRegisterSociety";
            this.btnRegisterSociety.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterSociety.TabIndex = 4;
            this.btnRegisterSociety.Text = "Register";
            this.btnRegisterSociety.UseVisualStyleBackColor = true;
            this.btnRegisterSociety.Click += new System.EventHandler(this.btnRegisterSociety_Click);

            // RegisterSociety
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btnRegisterSociety);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtSocietyName);
            this.Controls.Add(this.lblSocietyName);
            this.Name = "RegisterSociety";
            this.Text = "Register New Society";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSocietyName;
        private System.Windows.Forms.TextBox txtSocietyName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnRegisterSociety;
    }
}
