using System;
using System.Windows.Forms;
using ACCEntryListGenerator.Properties;

namespace ACCEntryListGenerator
{
    public partial class FormCsvSettings : Form
    {
        public FormCsvSettings()
        {
            InitializeComponent();
        }

        private void HandleOnFormLoad(object sender, EventArgs e)
        {
            // Fields
            firstNameTextBox.Text = Settings.Default.firstNameFieldAlias;
            lastNameTextBox.Text = Settings.Default.lastNameFieldAlias;
            shortNameTextBox.Text = Settings.Default.shortNameFieldAlias;
            categoryFieldTextBox.Text = Settings.Default.categoryFieldAlias;
            playerIdTextBox.Text = Settings.Default.playerIdFieldAlias;
            carModelTextBox.Text = Settings.Default.carModelFieldAlias;

            // Properties
            categoryPropertyPlatinumTextBox.Text = Settings.Default.categoryPropertyPlatinumAlias;
            categoryPropertyGoldTextBox.Text = Settings.Default.categoryPropertyGoldAlias;
            categoryPropertySilverTextBox.Text = Settings.Default.categoryPropertySilverAlias;
            categoryPropertyBronzeTextBox.Text = Settings.Default.categoryPropertyBronzeAlias;
        }

        private void HandleOnFormClosing(object sender, FormClosingEventArgs e)
        {
            // Fields
            Settings.Default.firstNameFieldAlias = firstNameTextBox.Text;
            Settings.Default.lastNameFieldAlias = lastNameTextBox.Text;
            Settings.Default.shortNameFieldAlias = shortNameTextBox.Text;
            Settings.Default.categoryFieldAlias = categoryFieldTextBox.Text;
            Settings.Default.playerIdFieldAlias = playerIdTextBox.Text;
            Settings.Default.carModelFieldAlias = carModelTextBox.Text;

            // Properties
            Settings.Default.categoryPropertyPlatinumAlias = categoryPropertyPlatinumTextBox.Text;
            Settings.Default.categoryPropertyGoldAlias = categoryPropertyGoldTextBox.Text;
            Settings.Default.categoryPropertySilverAlias = categoryPropertySilverTextBox.Text;
            Settings.Default.categoryPropertyBronzeAlias = categoryPropertyBronzeTextBox.Text;

            Settings.Default.Save();
        }
    }
}
