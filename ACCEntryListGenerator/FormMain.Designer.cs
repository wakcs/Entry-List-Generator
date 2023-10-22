
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
            this.JsonRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CsvRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CsvImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CsvSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.JsonRootToolStripMenuItem,
            this.CsvRootToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // JsonRootToolStripMenuItem
            // 
            this.JsonRootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JsonImportToolStripMenuItem,
            this.JsonExportToolStripMenuItem});
            this.JsonRootToolStripMenuItem.Name = "JsonRootToolStripMenuItem";
            this.JsonRootToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.JsonRootToolStripMenuItem.Text = "JSON";
            // 
            // JsonImportToolStripMenuItem
            // 
            this.JsonImportToolStripMenuItem.Name = "JsonImportToolStripMenuItem";
            this.JsonImportToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.JsonImportToolStripMenuItem.Text = "Import File";
            this.JsonImportToolStripMenuItem.Click += new System.EventHandler(this.HandleOnImportJsonClicked);
            // 
            // JsonExportToolStripMenuItem
            // 
            this.JsonExportToolStripMenuItem.Name = "JsonExportToolStripMenuItem";
            this.JsonExportToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.JsonExportToolStripMenuItem.Text = "Export File";
            this.JsonExportToolStripMenuItem.Click += new System.EventHandler(this.HandleOnJsonExportClicked);
            // 
            // CsvRootToolStripMenuItem
            // 
            this.CsvRootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CsvImportToolStripMenuItem,
            this.CsvSettingsToolStripMenuItem});
            this.CsvRootToolStripMenuItem.Name = "CsvRootToolStripMenuItem";
            this.CsvRootToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.CsvRootToolStripMenuItem.Text = "CSV";
            // 
            // CsvImportToolStripMenuItem
            // 
            this.CsvImportToolStripMenuItem.Name = "CsvImportToolStripMenuItem";
            this.CsvImportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CsvImportToolStripMenuItem.Text = "Import File";
            this.CsvImportToolStripMenuItem.Click += new System.EventHandler(this.HandleOnCsvImportClicked);
            // 
            // CsvSettingsToolStripMenuItem
            // 
            this.CsvSettingsToolStripMenuItem.Name = "CsvSettingsToolStripMenuItem";
            this.CsvSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CsvSettingsToolStripMenuItem.Text = "Import Settings";
            this.CsvSettingsToolStripMenuItem.Click += new System.EventHandler(this.HandleOnCsvSettingsClicked);
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
            this.CarModel.Items.AddRange(new object[] {
            "NONE",
            "Alpine A110 GT4 (2018)",
            "AMR V12 Vantage GT3 (2013)",
            "AMR V8 Vantage (2019)",
            "Aston Martin Vantage GT4 (2018)",
            "Audi R8 LMS (2015)",
            "Audi R8 LMS Evo (2019)",
            "Audi R8 LMS GT3 Evo 2 (2022)",
            "Audi R8 LMS GT4 (2018)",
            "Bentley Continental GT3 (2015)",
            "Bentley Continental GT3 (2018)",
            "BMW M2 Club Sport Racing (2020)",
            "BMW M4 GT3 (2022)",
            "BMW M4 GT4 (2018)",
            "BMW M6 GT3 (2017)",
            "Chevrolet Camaro GT4 (2017)",
            "Emil Frey Jaguar G3 (2012)",
            "Ferrari 296 GT3 (2023)",
            "Ferrari 488 Challenge Evo (2020)",
            "Ferrari 488 GT3 (2018)",
            "Ferrari 488 GT3 Evo (2020)",
            "Ginetta G55 GT4 (2012)",
            "Honda NSX GT3 (2017)",
            "Honda NSX GT3 Evo (2019)",
            "KTM X-Bow GT4 (2016)",
            "Lamborghini Huracan Evo2 (2023)",
            "Lamborghini Huracan GT3 (2015)",
            "Lamborghini Huracan GT3 Evo",
            "Lamborghini Huracan SuperTrofeo (2015)",
            "Lamborghini Huracán SuperTrofeo EVO2 (2021)",
            "Lexus RC F GT3 (2016)",
            "Maserati MC GT4 (2016)",
            "McLaren 570S GT4 (2016)",
            "McLaren 650S GT3 (2015)",
            "McLaren 720S GT3 (2019)",
            "McLaren 720S GT3 Evo (2023)",
            "Mercedes AMG GT4 (2016)",
            "Mercedes-AMG GT3 (2015)",
            "Mercedes-AMG GT3 (2020)",
            "Nissan GT-R Nismo GT3 (2015)",
            "Nissan GT-R Nismo GT3 (2018)",
            "Porsche 718 Cayman GT4 Clubsport (2019)",
            "Porsche 911 II GT3 R (2019)",
            "Porsche 991 GT3 R (2018)",
            "Porsche 991 II GT3 Cup (2017)",
            "Porsche 992 GT3 Cup (2021)",
            "Porsche 992 GT3 R (2023)",
            "Reiter Engineering R-EX GT3 (2017)"});
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
        private System.Windows.Forms.ToolStripMenuItem JsonRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CsvRootToolStripMenuItem;
        private System.Windows.Forms.DataGridView entryListDataView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DriverCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn CarModel;
        private System.Windows.Forms.ToolStripMenuItem JsonImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JsonExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CsvImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CsvSettingsToolStripMenuItem;
    }
}

