﻿using System.Windows.Forms;

namespace SocietyManagementSystem
{
    partial class Dashboard
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem yourSocietiesToolStripMenuItem;
        private ToolStripMenuItem manageEventsToolStripMenuItem;
        private ToolStripMenuItem manageSocietiesToolStripMenuItem;
        private ToolStripMenuItem registerSocietyToolStripMenuItem;
        private ToolStripMenuItem joinSocietyToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem joinEventToolStripMenuItem;
        private Panel societiesPanel;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            profileToolStripMenuItem = new ToolStripMenuItem();
            yourSocietiesToolStripMenuItem = new ToolStripMenuItem();
            registerSocietyToolStripMenuItem = new ToolStripMenuItem();
            manageSocietiesToolStripMenuItem = new ToolStripMenuItem();
            manageEventsToolStripMenuItem = new ToolStripMenuItem();
            joinSocietyToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            joinEventToolStripMenuItem = new ToolStripMenuItem();
            societiesPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, yourSocietiesToolStripMenuItem, registerSocietyToolStripMenuItem, manageSocietiesToolStripMenuItem, manageEventsToolStripMenuItem, joinSocietyToolStripMenuItem, joinEventToolStripMenuItem, logoutToolStripMenuItem });
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
            profileToolStripMenuItem.Click += ProfileToolStripMenuItem_Click;
            // 
            // manageSocietiesToolStripMenuItem
            // 
            manageSocietiesToolStripMenuItem.Name = "manageSocietiesToolStripMenuItem";
            manageSocietiesToolStripMenuItem.Size = new Size(92, 20);
            manageSocietiesToolStripMenuItem.Text = "Manage Societies";
            manageSocietiesToolStripMenuItem.Click += ManageSocietiesToolStripMenuItem_Click;
            // 
            // manageEventsToolStripMenuItem
            // 
            manageEventsToolStripMenuItem.Name = "manageEventsToolStripMenuItem";
            manageEventsToolStripMenuItem.Size = new Size(102, 20);
            manageEventsToolStripMenuItem.Text = "Manage Events Resources";
            manageEventsToolStripMenuItem.Click += ManageEventsToolStripMenuItem_Click;
            // 
            // yourSocietiesToolStripMenuItem
            // 
            yourSocietiesToolStripMenuItem.Name = "yourSocietiesToolStripMenuItem";
            yourSocietiesToolStripMenuItem.Size = new Size(92, 20);
            yourSocietiesToolStripMenuItem.Text = "Your Societies";
            yourSocietiesToolStripMenuItem.Click += YourSocietiesToolStripMenuItem_Click_1;
            // 
            // registerSocietyToolStripMenuItem
            // 
            registerSocietyToolStripMenuItem.Name = "registerSocietyToolStripMenuItem";
            registerSocietyToolStripMenuItem.Size = new Size(102, 20);
            registerSocietyToolStripMenuItem.Text = "Register Society";
            registerSocietyToolStripMenuItem.Click += registerSocietyToolStripMenuItem_Click_1;
            // 
            // joinSocietyToolStripMenuItem
            // 
            joinSocietyToolStripMenuItem.Name = "joinSocietyToolStripMenuItem";
            joinSocietyToolStripMenuItem.Size = new Size(122, 20);
            joinSocietyToolStripMenuItem.Text = "Join Society";
            joinSocietyToolStripMenuItem.Click += JoinSocietyToolStripMenuItem_Click;
            // 
            // joinEventToolStripMenuItem
            // 
            joinEventToolStripMenuItem.Name = "joinEventToolStripMenuItem";
            joinEventToolStripMenuItem.Size = new Size(122, 20);
            joinEventToolStripMenuItem.Text = "Join Events";
            joinEventToolStripMenuItem.Click += JoinEventToolStripMenuItem_Click;
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
