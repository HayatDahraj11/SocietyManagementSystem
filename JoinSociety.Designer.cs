namespace SocietyManagementSystem
{
    partial class JoinSociety
    {
        private System.Windows.Forms.ListView lvSocieties;
        private System.Windows.Forms.Button btnJoin;

        private void InitializeComponent()
        {
            this.lvSocieties = new System.Windows.Forms.ListView();
            this.btnJoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvSocieties
            // 
            this.lvSocieties.Location = new System.Drawing.Point(12, 12);
            this.lvSocieties.Name = "lvSocieties";
            this.lvSocieties.Size = new System.Drawing.Size(260, 208);
            this.lvSocieties.TabIndex = 0;
            this.lvSocieties.UseCompatibleStateImageBehavior = false;
            this.lvSocieties.View = System.Windows.Forms.View.List;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(197, 226);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // JoinSociety
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.lvSocieties);
            this.Name = "JoinSociety";
            this.Text = "Join Society";
            this.Load += new System.EventHandler(this.JoinSociety_Load);
            this.ResumeLayout(false);
        }
    }
}