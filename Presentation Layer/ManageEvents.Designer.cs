// ManageEvents.Designer.cs
namespace SocietyManagementSystem
{
    partial class ManageEvents
    {
        private System.Windows.Forms.DataGridView eventsGrid;

        private void InitializeComponent()
        {
            this.eventsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // eventsGrid
            // 
            this.eventsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsGrid.Location = new System.Drawing.Point(12, 12);
            this.eventsGrid.Name = "eventsGrid";
            this.eventsGrid.Size = new System.Drawing.Size(776, 426);
            this.eventsGrid.TabIndex = 0;
            this.eventsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventsGrid_CellContentClick);
            // 
            // ManageEvents
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eventsGrid);
            this.Name = "ManageEvents";
            this.Load += new System.EventHandler(this.ManageEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
