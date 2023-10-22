using System;
using System.Windows.Forms;

namespace ACCEntryListGenerator
{
    public partial class FormMain : Form
    {
        private readonly EntryListGenerator _entryListGenerator = new EntryListGenerator();
        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
        private readonly FileDialog _fileDialog = new OpenFileDialog();
        private readonly FormCsvSettings formCsvSettings = new FormCsvSettings();

        private const string InvalidMessageHeader = "Invalid input";

        public FormMain()
        {
            InitializeComponent();
            CarModel.Items.Clear();
            CarModel.Items.AddRange(CarModelUtility.GetCarNames());
        }

        private bool TryGenerateDataFromGridView()
        {
            bool hasSavedData = false;
            _entryListGenerator.ResetEntryList();
            _entryListGenerator.SetForceEntryList(true);
            for (int i = 0; i < entryListDataView.RowCount; i++)
            {
                DataGridViewRow row = entryListDataView.Rows[i];

                bool hasInvalidValues = false;
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if(row.Cells[j].Value != null) continue;


                    MessageBox.Show($"Empty cell value in row {row.Index} at column {row.Cells[j].OwningColumn.HeaderText}");
                    hasInvalidValues = true;
                    break;
                }
                if(hasInvalidValues) continue;

                bool isAdmin = (bool) row.Cells[IsAdmin.Index].Value;
                string firstName = row.Cells[FirstName.Index].Value.ToString();
                string lastName = row.Cells[LastName.Index].Value.ToString();
                string shortName = row.Cells[ShortName.Index].Value.ToString();

                if (row.Cells[DriverCategory.Index] is not DataGridViewComboBoxCell driverCategoryCell)
                {
                    MessageBox.Show($"Failed to convert {nameof(driverCategoryCell)} to {nameof(DataGridViewComboBoxCell)}", "ERROR", MessageBoxButtons.OK);
                    continue;
                }
                EDriverCategory driverCategory = (EDriverCategory)driverCategoryCell.Items.IndexOf(driverCategoryCell.Value);

                if (row.Cells[CarModel.Index] is not DataGridViewComboBoxCell carModelCell)
                {
                    MessageBox.Show($"Failed to convert {nameof(carModelCell)} to {nameof(DataGridViewComboBoxCell)}", "ERROR", MessageBoxButtons.OK);
                    continue;
                }

                CarModelUtility.TryGetCarModelForName(carModelCell.Value.ToString(), out ECarModel carModel);

                string playerIdValue = row.Cells[PlayerId.Index].Value.ToString();
                if (!long.TryParse(playerIdValue, out long playerId))
                {
                    MessageBox.Show($"Player ID  ({playerIdValue}) is not a valid value at row {i}", InvalidMessageHeader, MessageBoxButtons.OK);
                    continue;
                }

                string raceNumberValue = row.Cells[CarNumber.Index].Value.ToString();
                if (!uint.TryParse(raceNumberValue, out uint raceNumber) || raceNumber > 999)
                {
                    MessageBox.Show($"Racenumber ({raceNumberValue}) is not a valid value, must be between 0 and 999 at row {i}", InvalidMessageHeader, MessageBoxButtons.OK);
                    continue;
                }

                _entryListGenerator.AddEntry(raceNumber, isAdmin, true, carModel);
                _entryListGenerator.AddDriver(raceNumber, playerId, firstName, lastName, shortName, driverCategory);
                hasSavedData = true;
            }

            return hasSavedData;
        }

        private void UpdateGridViewFromData()
        {
            DataGridViewRow rowTemplate = (DataGridViewRow)entryListDataView.Rows[0].Clone();
            entryListDataView.Rows.Clear();
            for (int i = 0; i < _entryListGenerator.EntryListData.entries.Count; i++)
            {
                EntryListData.EntryData entry = _entryListGenerator.EntryListData.entries[i];
                foreach (EntryListData.DriverData driver in entry.drivers)
                {
                    DataGridViewRow row = (DataGridViewRow) rowTemplate.Clone();
                    row.Cells[IsAdmin.Index].Value = Convert.ToBoolean(entry.isServerAdmin);
                    row.Cells[FirstName.Index].Value = driver.firstName;
                    row.Cells[LastName.Index].Value = driver.lastName;
                    row.Cells[ShortName.Index].Value = driver.shortName;

                    row.Cells[PlayerId.Index].Value = driver.playerID.Substring(1);
                    row.Cells[CarNumber.Index].Value = entry.raceNumber;
                    row.Cells[DriverCategory.Index].Value = DriverCategory.Items[(int) driver.driverCategory];
                    row.Cells[CarModel.Index].Value = CarModelUtility.GetCarNameForIndex(entry.forcedCarModel);

                    entryListDataView.Rows.Add(row);
                }
            }
        }
        

        private void HandleEntryListDataViewCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            entryListDataView.Rows[e.RowIndex].ErrorText = string.Empty;
            if (string.IsNullOrEmpty(e.FormattedValue.ToString())) return;
            
            if (e.ColumnIndex == PlayerId.Index) {
                if (long.TryParse(e.FormattedValue.ToString(), out long result)) return;
                e.Cancel = true;
                entryListDataView.Rows[e.RowIndex].ErrorText = "PlayerId is not a numerical value";
            }else if (e.ColumnIndex == CarNumber.Index) {
                if (uint.TryParse(e.FormattedValue.ToString(), out uint result) && result <= 999) return;
                e.Cancel = true;
                entryListDataView.Rows[e.RowIndex].ErrorText = "Car number must be between 0 and 999";
            }else if (e.ColumnIndex == ShortName.Index) {
                if (!(e.FormattedValue.ToString()?.Length > 3)) return;
                e.Cancel = true;
                entryListDataView.Rows[e.RowIndex].ErrorText = "Short name cannot be longer than 3 symbols";
            }
        }

        private void HandleOnImportJsonClicked(object sender, EventArgs e)
        {
            _fileDialog.Filter = "JSON|*.json";
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                _entryListGenerator.ImportEntryListFromJsonFile(_fileDialog.FileName);
                UpdateGridViewFromData();
            }
        }

        private void HandleOnJsonExportClicked(object sender, EventArgs e)
        {
            entryListDataView.EndEdit();
            if (!TryGenerateDataFromGridView()) return;

            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _entryListGenerator.ExportEntryListToFile(_folderBrowserDialog.SelectedPath);
            }
        }

        private void HandleOnCsvImportClicked(object sender, EventArgs e)
        {
            _fileDialog.Filter = "CSV|*.csv";
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                _entryListGenerator.ImportEntryListFromCsvFile(_fileDialog.FileName);
                UpdateGridViewFromData();
            }
        }

        private void HandleOnCsvSettingsClicked(object sender, EventArgs e)
        {
            formCsvSettings.ShowDialog();
        }
    }
}
