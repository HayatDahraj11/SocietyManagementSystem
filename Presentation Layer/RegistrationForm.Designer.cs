using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class RegistrationForm
    {
        private Label nameLabel;
        private Label usernameLabel;
        private Label emailLabel;
        private Label passwordLabel;
        private Label userTypeLabel;
        private TextBox usernameTextBox;
        private TextBox nameTextBox;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private ComboBox userTypeComboBox;
        private Button registerButton;

        private void InitializeComponent()
        {
            nameLabel = new Label();
            usernameLabel = new Label();
            emailLabel = new Label();
            passwordLabel = new Label();
            userTypeLabel = new Label();
            nameTextBox = new TextBox();
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            userTypeComboBox = new ComboBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(25, 10);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(64, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Full Name:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(25, 60);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(25, 110);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(25, 160);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Password:";
            // 
            // userTypeLabel
            // 
            userTypeLabel.AutoSize = true;
            userTypeLabel.Location = new Point(25, 210);
            userTypeLabel.Name = "userTypeLabel";
            userTypeLabel.Size = new Size(60, 15);
            userTypeLabel.TabIndex = 8;
            userTypeLabel.Text = "User Type:";

            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(25, 30);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(300, 23);
            nameTextBox.TabIndex = 1;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(25, 80);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(300, 23);
            usernameTextBox.TabIndex = 3;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(25, 130);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(300, 23);
            emailTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(25, 180);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(300, 23);
            passwordTextBox.TabIndex = 7;
            // 
            // userTypeComboBox
            // 
            userTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            userTypeComboBox.Items.AddRange(new object[] { "student", "mentor"});
            userTypeComboBox.Location = new Point(25, 230);
            userTypeComboBox.Name = "userTypeComboBox";
            userTypeComboBox.Size = new Size(300, 23);
            userTypeComboBox.TabIndex = 9;
          
            // 
            // registerButton
            // 
            registerButton.Location = new Point(125, 320);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(100, 30);
            registerButton.TabIndex = 12;
            registerButton.Text = "Register";
            registerButton.Click += RegisterButton_Click;
            // 
            // RegistrationForm
            // 
            ClientSize = new Size(350, 400);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(userTypeLabel);
            Controls.Add(userTypeComboBox);

            Controls.Add(registerButton);
            Name = "RegistrationForm";
            Text = "User Registration";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
