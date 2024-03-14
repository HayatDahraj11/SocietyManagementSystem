using System.Drawing;
using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button registerButton;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label titleLabel;

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
            components = new System.ComponentModel.Container();
            this.usernameTextBox = new TextBox();
            this.passwordTextBox = new TextBox();
            this.loginButton = new Button();
            this.registerButton = new Button();
            this.titleLabel = new Label();
            this.usernameLabel = new Label();
            this.passwordLabel = new Label();

            // LoginForm
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(320, 180);
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fast Society Management System";

            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.titleLabel.ForeColor = Color.FromArgb(30, 30, 30);
            this.titleLabel.Location = new Point(50, 15);
            this.titleLabel.Size = new Size(220, 21);
            this.titleLabel.Text = "Fast Society Management";

            // usernameLabel
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new Point(73, 50);
            this.usernameLabel.Text = "Username";

            // passwordLabel
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new Point(73, 100);
            this.passwordLabel.Text = "Password";

            // usernameTextBox
            this.usernameTextBox.Location = new Point(73, 70);
            this.usernameTextBox.Size = new Size(174, 20);

            // passwordTextBox
            this.passwordTextBox.Location = new Point(73, 120);
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new Size(174, 20);

            // loginButton
            this.loginButton.BackColor = Color.FromArgb(100, 149, 237);
            this.loginButton.FlatStyle = FlatStyle.Flat;
            this.loginButton.ForeColor = Color.White;
            this.loginButton.Location = new Point(73, 150);
            this.loginButton.Size = new Size(75, 23);
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;

            // registerButton
            this.registerButton.BackColor = Color.FromArgb(255, 69, 0);
            this.registerButton.FlatStyle = FlatStyle.Flat;
            this.registerButton.ForeColor = Color.White;
            this.registerButton.Location = new Point(172, 150);
            this.registerButton.Size = new Size(75, 23);
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;

            // Add controls to the form
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registerButton);
        }
    }
}
