using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class Dashboard
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem yourSocietiesToolStripMenuItem;
        private ToolStripMenuItem registerSocietyToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private Panel societiesPanel;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            profileToolStripMenuItem = new ToolStripMenuItem();
            yourSocietiesToolStripMenuItem = new ToolStripMenuItem();
            registerSocietyToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            societiesPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, yourSocietiesToolStripMenuItem, registerSocietyToolStripMenuItem, logoutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(53, 20);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // yourSocietiesToolStripMenuItem
            // 
            yourSocietiesToolStripMenuItem.Name = "yourSocietiesToolStripMenuItem";
            yourSocietiesToolStripMenuItem.Size = new Size(92, 20);
            yourSocietiesToolStripMenuItem.Text = "Your Societies";
            // 
            // registerSocietyToolStripMenuItem
            // 
            registerSocietyToolStripMenuItem.Name = "registerSocietyToolStripMenuItem";
            registerSocietyToolStripMenuItem.Size = new Size(102, 20);
            registerSocietyToolStripMenuItem.Text = "Register Society";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(57, 20);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;
            // 
            // societiesPanel
            // 
            societiesPanel.AutoScroll = true;
            societiesPanel.Location = new Point(12, 27);
            societiesPanel.Name = "societiesPanel";
            societiesPanel.Size = new Size(776, 411);
            societiesPanel.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(societiesPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
