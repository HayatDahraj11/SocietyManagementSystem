namespace SocietyManagementSystem
{
    partial class ManageSocieties
    {
        private System.Windows.Forms.DataGridView societiesGrid;

        private void InitializeComponent()
        {
            this.societiesGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.societiesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // societiesGrid
            // 
            this.societiesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.societiesGrid.Location = new System.Drawing.Point(12, 12);
            this.societiesGrid.Name = "societiesGrid";
            this.societiesGrid.Size = new System.Drawing.Size(776, 426);
            this.societiesGrid.TabIndex = 0;
            this.societiesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.societiesGrid_CellContentClick);
            // 
            // ManageSocieties
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.societiesGrid);
            this.Name = "ManageSocieties";
            this.Load += new System.EventHandler(this.ManageSocieties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.societiesGrid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}