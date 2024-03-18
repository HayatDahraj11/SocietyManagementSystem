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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yourSocietiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerSocietyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.societiesPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.yourSocietiesToolStripMenuItem,
            this.registerSocietyToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1066, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click_1);
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.mToolStripMenuItem.Text = "m";
            // 
            // yourSocietiesToolStripMenuItem
            // 
            this.yourSocietiesToolStripMenuItem.Name = "yourSocietiesToolStripMenuItem";
            this.yourSocietiesToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.yourSocietiesToolStripMenuItem.Text = "Your Societies";
            this.yourSocietiesToolStripMenuItem.Click += new System.EventHandler(this.yourSocietiesToolStripMenuItem_Click_1);
            // 
            // registerSocietyToolStripMenuItem
            // 
            this.registerSocietyToolStripMenuItem.Name = "registerSocietyToolStripMenuItem";
            this.registerSocietyToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.registerSocietyToolStripMenuItem.Text = "Register Society";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // societiesPanel
            // 
            this.societiesPanel.AutoScroll = true;
            this.societiesPanel.Location = new System.Drawing.Point(14, 36);
            this.societiesPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.societiesPanel.Name = "societiesPanel";
            this.societiesPanel.Size = new System.Drawing.Size(887, 548);
            this.societiesPanel.TabIndex = 0;
            this.societiesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.societiesPanel_Paint);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 692);
            this.Controls.Add(this.societiesPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStripMenuItem mToolStripMenuItem;
    }
}
