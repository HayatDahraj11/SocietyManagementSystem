using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class Profile
    {

        // UI elements are declared here
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUserType;
        private Label lblUserType2;

        private Button btnSaveChanges;
        private Button btnChangePassword;

        private Label labelSocieties;
        private ListView lvSocieties;
        private Label labelEvents;
        private ListView lvEvents;


        private void InitializeComponent()
        {
            lvSocieties = new ListView();
            lvEvents = new ListView();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSaveChanges = new Button();
            labelSocieties = new Label();
            labelEvents = new Label();
            btnChangePassword = new Button();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUserType = new Label();
            lblUserType2 = new Label();
            SuspendLayout();
            // 
            // lvSocieties
            // 
            lvSocieties.FullRowSelect = true;
            lvSocieties.Location = new Point(18, 188);
            lvSocieties.Margin = new Padding(4, 3, 4, 3);
            lvSocieties.Name = "lvSocieties";
            lvSocieties.Size = new Size(305, 170);
            lvSocieties.TabIndex = 7;
            lvSocieties.UseCompatibleStateImageBehavior = false;
            lvSocieties.View = View.Details;
            lvSocieties.SelectedIndexChanged += lvSocieties_SelectedIndexChanged;
            // 
            // lvEvents
            // 
            lvEvents.FullRowSelect = true;
            lvEvents.Location = new Point(351, 188);
            lvEvents.Margin = new Padding(4, 3, 4, 3);
            lvEvents.Name = "lvEvents";
            lvEvents.Size = new Size(304, 170);
            lvEvents.TabIndex = 8;
            lvEvents.UseCompatibleStateImageBehavior = false;
            lvEvents.View = View.Details;
            lvEvents.SelectedIndexChanged += lvEvents_SelectedIndexChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(18, 24);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(147, 24);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(133, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(18, 54);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(147, 53);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(133, 23);
            txtEmail.TabIndex = 3;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(234, 94);
            btnSaveChanges.Margin = new Padding(4, 3, 4, 3);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(188, 27);
            btnSaveChanges.TabIndex = 6;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // labelSocieties
            // 
            labelSocieties.AutoSize = true;
            labelSocieties.Location = new Point(12, 170);
            labelSocieties.Name = "labelSocieties";
            labelSocieties.Size = new Size(83, 15);
            labelSocieties.TabIndex = 9;
            labelSocieties.Text = "Your Societies:";
            labelSocieties.Click += labelSocieties_Click;
            // 
            // labelEvents
            // 
            labelEvents.AutoSize = true;
            labelEvents.Location = new Point(351, 170);
            labelEvents.Name = "labelEvents";
            labelEvents.Size = new Size(71, 15);
            labelEvents.TabIndex = 10;
            labelEvents.Text = "Your Events:";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(234, 127);
            btnChangePassword.Margin = new Padding(4, 3, 4, 3);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(188, 27);
            btnChangePassword.TabIndex = 11;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(393, 24);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(61, 15);
            lblFullName.TabIndex = 12;
            lblFullName.Text = "FullName:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(522, 24);
            txtFullName.Margin = new Padding(4, 3, 4, 3);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(133, 23);
            txtFullName.TabIndex = 13;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Location = new Point(393, 54);
            lblUserType.Margin = new Padding(4, 0, 4, 0);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(57, 15);
            lblUserType.TabIndex = 14;
            lblUserType.Text = "UserType:";
            lblUserType.Click += lblUserType_Click;
            // 
            // lblUserType2
            // 
            lblUserType2.AutoSize = true;
            lblUserType2.Location = new Point(522, 53);
            lblUserType2.Margin = new Padding(4, 3, 4, 3);
            lblUserType2.Name = "lblUserType2";
            lblUserType2.Size = new Size(0, 15);
            lblUserType2.TabIndex = 15;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 371);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblUserType);
            Controls.Add(lblUserType2);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnSaveChanges);
            Controls.Add(lvSocieties);
            Controls.Add(lvEvents);
            Controls.Add(labelSocieties);
            Controls.Add(labelEvents);
            Controls.Add(btnChangePassword);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Profile";
            Text = "Profile";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}