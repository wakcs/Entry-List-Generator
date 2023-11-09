using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ACCEntryListGenerator.Properties;
using Microsoft.VisualBasic.FileIO;

namespace ACCEntryListGenerator
{
    public class EntryListGenerator
    {
        private struct DriverImportData
        {
            public int? FirstNameIndex;
            public int? LastNameIndex;
            public int? ShortNameIndex;
            public int? PlayerIdIndex;
            public int? CategoryIndex;

            public bool IsValidDriver()
            {
                return FirstNameIndex.HasValue &&
                       LastNameIndex.HasValue &&
                       ShortNameIndex.HasValue &&
                       PlayerIdIndex.HasValue &&
                       CategoryIndex.HasValue;
            }
        }

        public EntryListData EntryListData => _entryListData;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions {WriteIndented = true};
        private EntryListData _entryListData;

        public EntryListGenerator()
        {
            ResetEntryList();
        }
        
        public void ResetEntryList()
        {
            _entryListData = default;
            _entryListData.entries = new List<EntryListData.EntryData>();
        }

        public void SetForceEntryList(bool forceEntryList)
        {
            _entryListData.forceEntryList = Convert.ToByte(forceEntryList);
        }

        public void AddEntry(uint raceNumber, bool isServerAdmin, bool overrideDriverInfo, ECarModel carModel, EntryListData.DriverData[] drivers = null)
        {
            if(raceNumber > 999)
            {
                Console.WriteLine($"{nameof(raceNumber)}({raceNumber}) cannot be higher than 999!");
                return;
            }

            if (_entryListData.entries.Exists(entry => entry.raceNumber == raceNumber))
            {
                Console.WriteLine($"entry with {nameof(raceNumber)}({raceNumber}) already exists!");
                return;
            }

            EntryListData.EntryData entryData = new()
            {
                raceNumber = raceNumber,
                overrideDriverInfo = Convert.ToByte(overrideDriverInfo),
                isServerAdmin = Convert.ToByte(isServerAdmin),
                forcedCarModel = (int)carModel,
                drivers = drivers != null ? new List<EntryListData.DriverData>(drivers) : new List<EntryListData.DriverData>()
            };

            _entryListData.entries.Add(entryData);
        }

        public void RemoveEntry(uint raceNumber)
        {
            int entryIndex = _entryListData.entries.FindIndex(entry => entry.raceNumber == raceNumber);
            if (entryIndex < 0)
            {
                Console.WriteLine($"entry with {nameof(raceNumber)}({raceNumber}) does not exist");
                return;
            }
            _entryListData.entries.RemoveAt(entryIndex);
        }

        public void AddDriver(uint raceNumber, long playerId, string firstName, string lastName, string shortName, EDriverCategory driverCategory)
        {
            int entryIndex = _entryListData.entries.FindIndex(entry => entry.raceNumber == raceNumber);
            if(entryIndex < 0)
            {
                Console.WriteLine($"Failed to find entry with {nameof(raceNumber)}({raceNumber})");
                return;
            }
            
            if(shortName.Length > 3)
            {
                Console.WriteLine($"{nameof(shortName)}({shortName}) is longer than 3 characters, shorting it...");
                shortName = shortName.Substring(0, 3);
            }

            EntryListData.DriverData driverData = new()
            {
                firstName = firstName,
                lastName = lastName,
                shortName = shortName,
                driverCategory = (uint)driverCategory,
                playerID = $"S{playerId}"
            };

            _entryListData.entries[entryIndex].drivers.Add(driverData);
        }

        public void RemoveDriver(uint raceNumber, long playerId)
        {
            int entryIndex = _entryListData.entries.FindIndex(entry => entry.raceNumber == raceNumber);
            if (entryIndex < 0)
            {
                Console.WriteLine($"Failed to find entry with {nameof(raceNumber)}({raceNumber})");
                return;
            }

            string formattedPlayerId = $"S{playerId}";

            int driverIndex = _entryListData.entries[entryIndex].drivers.FindIndex(driver => string.Equals(driver.playerID, formattedPlayerId));
            if(driverIndex < 0)
            {
                Console.WriteLine($"entry with {nameof(raceNumber)}({raceNumber}) does not have a driver with ID {playerId}");
                return;
            }
            _entryListData.entries[entryIndex].drivers.RemoveAt(driverIndex);
        }

        public void ExportEntryListToFile(string path)
        {
            try
            {
                string jsonResult = JsonSerializer.Serialize(_entryListData, _jsonSerializerOptions);
                if (!path.EndsWith(".json"))
                {
                    path += "/entrylist.json";
                }
                File.WriteAllText(path, jsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ImportEntryListFromJsonFile(string path)
        {
            try
            {
                string jsonData = File.ReadAllText(path);
                _entryListData = JsonSerializer.Deserialize<EntryListData>(jsonData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ImportEntryListFromCsvFile(string path)
        {
            try
            {
                using (TextFieldParser textFieldParser = new TextFieldParser(path))
                {
                    textFieldParser.TextFieldType = FieldType.Delimited;
                    textFieldParser.SetDelimiters(",");

                    int carNumberIndex = 0,
                        carModelIndex = 0;
                    List<DriverImportData> driverList = new List<DriverImportData>();

                    bool columnsInitiated = false;
                    while (!textFieldParser.EndOfData)
                    {
                        string[] fields = textFieldParser.ReadFields();
                        if (!columnsInitiated)
                        {
                            DriverImportData driver = new DriverImportData();
                            for (int i = 0; i < fields?.Length; i++)
                            {
                                switch (fields[i])
                                {
                                    case "First Name":
                                        driver.FirstNameIndex = i;
                                        break;
                                    case "Last Name":
                                        driver.LastNameIndex = i;
                                        break;
                                    case "Short Name":
                                        driver.ShortNameIndex = i;
                                        break;
                                    case "Player ID":
                                        driver.PlayerIdIndex = i;
                                        break;
                                    case "Category":
                                        driver.CategoryIndex = i;
                                        break;
                                    case "Car Model":
                                        carModelIndex = i;
                                        break;
                                    case "Car Number":
                                        carNumberIndex = i;
                                        break;
                                    default:
                                        if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.firstNameFieldAlias))
                                        {
                                            driver.FirstNameIndex = i;
                                        }
                                        else if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.lastNameFieldAlias))
                                        {
                                            driver.LastNameIndex = i;
                                        }
                                        else if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.shortNameFieldAlias))
                                        {
                                            driver.ShortNameIndex = i;
                                        }
                                        else if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.playerIdFieldAlias))
                                        {
                                            driver.PlayerIdIndex = i;
                                        }
                                        else if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.categoryFieldAlias))
                                        {
                                            driver.CategoryIndex = i;
                                        }
                                        else if (CsvEntryListGenerator.DoesFieldExistInSetting(fields[i], Settings.Default.carModelFieldAlias))
                                        {
                                            carModelIndex = i;
                                        }
                                        break;
                                }

                                if (driver.IsValidDriver())
                                {
                                    driverList.Add(driver);
                                    driver = new DriverImportData();
                                }
                            }
                            columnsInitiated = true;
                        }
                        else if(driverList.Count > 0)
                        {
                            if(fields == null) continue;
                            // Create car entry
                            if (!uint.TryParse(fields[carNumberIndex], out uint carNumber))
                            {
                                continue;
                            }
                            
                            if (!CarModelUtility.TryGetCarModelForName(fields[carModelIndex], out ECarModel carModel))
                            {
                                for (int i = 0; i < CarModelUtility.ECarModelNames.Length; i++)
                                {
                                    if (!string.Equals(fields[carModelIndex], CarModelUtility.ECarModelNames[i], StringComparison.InvariantCultureIgnoreCase)) continue;
                                    carModel = Enum.Parse<ECarModel>(CarModelUtility.ECarModelNames[i]);
                                }
                            }

                            AddEntry(carNumber, false, true, carModel);

                            // Create driver entries
                            foreach (DriverImportData driver in driverList)
                            {


                                if (!long.TryParse(fields[driver.PlayerIdIndex.Value], out long playerId))
                                {
                                    continue;
                                }

                                string firstName = fields[driver.FirstNameIndex.Value];
                                string lastName = fields[driver.LastNameIndex.Value];
                                string shortName = fields[driver.ShortNameIndex.Value];

                                EDriverCategory category;
                                switch (fields[driver.CategoryIndex.Value])
                                {
                                    case nameof(EDriverCategory.Platinum):
                                        category = EDriverCategory.Platinum;
                                        break;
                                    case nameof(EDriverCategory.Gold):
                                        category = EDriverCategory.Gold;
                                        break;
                                    case nameof(EDriverCategory.Silver):
                                        category = EDriverCategory.Silver;
                                        break;
                                    case nameof(EDriverCategory.Bronze):
                                        category = EDriverCategory.Bronze;
                                        break;
                                    default:
                                        category = CsvEntryListGenerator.GetCategoryFromCustomSetting(fields[driver.CategoryIndex.Value]);
                                        break;
                                }
                                
                                AddDriver(carNumber, playerId, firstName, lastName, shortName, category);
                            }
                        }
                        else
                        {
                            // Return error no drivers found
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
