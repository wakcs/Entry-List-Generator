
namespace ACCEntryListGenerator
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entryListDataView = new System.Windows.Forms.DataGridView();
            this.IsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryListDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importJSONToolStripMenuItem,
            this.importCSVToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.HandleOnExportClicked);
            // 
            // importJSONToolStripMenuItem
            // 
            this.importJSONToolStripMenuItem.Name = "importJSONToolStripMenuItem";
            this.importJSONToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.importJSONToolStripMenuItem.Text = "Import (JSON)";
            this.importJSONToolStripMenuItem.Click += new System.EventHandler(this.HandleOnImportJsonClicked);
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.importCSVToolStripMenuItem.Text = "Import (CSV)";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.HandleOnImportCsvClicked);
            // 
            // entryListDataView
            // 
            this.entryListDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryListDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryListDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsAdmin,
            this.FirstName,
            this.LastName,
            this.ShortName,
            this.DriverCategory,
            this.PlayerId,
            this.CarNumber,
            this.CarModel});
            this.entryListDataView.Location = new System.Drawing.Point(12, 27);
            this.entryListDataView.Name = "entryListDataView";
            this.entryListDataView.RowTemplate.Height = 25;
            this.entryListDataView.Size = new System.Drawing.Size(843, 522);
            this.entryListDataView.TabIndex = 1;
            this.entryListDataView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.HandleEntryListDataViewCellValidating);
            // 
            // IsAdmin
            // 
            this.IsAdmin.HeaderText = "Is Admin";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.Width = 50;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // ShortName
            // 
            this.ShortName.HeaderText = "Short Name";
            this.ShortName.Name = "ShortName";
            this.ShortName.Width = 50;
            // 
            // DriverCategory
            // 
            this.DriverCategory.HeaderText = "Category";
            this.DriverCategory.Items.AddRange(new object[] {
            "Bronze",
            "Silver",
            "Gold",
            "Platinum"});
            this.DriverCategory.Name = "DriverCategory";
            // 
            // PlayerId
            // 
            this.PlayerId.HeaderText = "Steam ID";
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.Width = 150;
            // 
            // CarNumber
            // 
            this.CarNumber.HeaderText = "#";
            this.CarNumber.Name = "CarNumber";
            this.CarNumber.Width = 50;
            // 
            // CarModel
            // 
            this.CarModel.HeaderText = "Car Model";
            this.CarModel.Items.AddRange(CarModelUtility.GetCarNames());
            this.CarModel.Name = "CarModel";
            this.CarModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CarModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CarModel.Width = 250;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 561);
            this.Controls.Add(this.entryListDataView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Entry List Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryListDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.DataGridView entryListDataView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DriverCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn CarModel;
    }
}

