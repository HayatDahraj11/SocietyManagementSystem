namespace SocietyManagementSystem
{
    partial class JoinEventsForm
    {
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.Button btnJoin;

        private void InitializeComponent()
        {
            this.lvEvents = new System.Windows.Forms.ListView();
            this.btnJoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvEvents
            // 
            this.lvEvents.Location = new System.Drawing.Point(12, 12);
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(260, 208);
            this.lvEvents.TabIndex = 0;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.List;
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
            // JoinEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.lvEvents);
            this.Name = "JoinEvents";
            this.Text = "Join Events";
            this.Load += new System.EventHandler(this.JoinEventsForm_Load);
            this.ResumeLayout(false);
        }
    }
}