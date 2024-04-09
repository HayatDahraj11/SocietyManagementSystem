namespace SocietyManagementSystem
{
    partial class ChangeMemberRoleForm
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
            cmbRoles = new ComboBox();
            btnSave = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(64, 53);
            cmbRoles.Margin = new Padding(4, 3, 4, 3);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(140, 23);
            cmbRoles.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(92, 82);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 31);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 2;
            label1.Text = "Choose Role";
            label1.Click += label1_Click;
            // 
            // ChangeMemberRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 141);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(cmbRoles);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChangeMemberRoleForm";
            Text = "Change Member Role";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnSave;
        private Label label1;
    }
}