using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;

namespace ACCEntryListGenerator
{
    public class EntryListGenerator
    {
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
                File.WriteAllText(path + "/entrylist.json", jsonResult);
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

                    int firstNameIndex = 0,
                        lastNameIndex = 0,
                        shortNameIndex = 0,
                        categoryIndex = 0,
                        playerIdIndex = 0,
                        carNumberIndex = 0,
                        carModelIndex = 0;

                    bool columnsInitiated = false;
                    while (!textFieldParser.EndOfData)
                    {
                        string[] fields = textFieldParser.ReadFields();
                        if (!columnsInitiated)
                        {
                            for (int i = 0; i < fields?.Length; i++)
                            {
                                switch (fields[i])
                                {
                                    case "First Name":
                                        firstNameIndex = i;
                                        break;
                                    case "Last Name":
                                        lastNameIndex = i;
                                        break;
                                    case "Short Name":
                                        shortNameIndex = i;
                                        break;
                                    case "Category":
                                    case "Split":
                                        categoryIndex = i;
                                        break;
                                    case "Player ID":
                                    case "Steam ID64":
                                        playerIdIndex = i;
                                        break;
                                    case "Car":
                                    case "Car Model":
                                        carModelIndex = i;
                                        break;
                                    case "Car Number":
                                        carNumberIndex = i;
                                        break;
                                }
                            }
                            columnsInitiated = true;
                        }
                        else
                        {
                            if(fields == null) continue;
                            if (!uint.TryParse(fields[carNumberIndex], out uint carNumber))
                            {
                                continue;
                            }

                            if (!long.TryParse(fields[playerIdIndex], out long playerId))
                            {
                                continue;
                            }

                            string firstName = fields[firstNameIndex];
                            string lastName = fields[lastNameIndex];
                            string shortName = fields[shortNameIndex];

                            EDriverCategory category;
                            switch (fields[categoryIndex])
                            {
                                case nameof(EDriverCategory.Platinum):
                                case "Pro":
                                    category = EDriverCategory.Platinum;
                                    break;
                                case nameof(EDriverCategory.Gold):
                                    category = EDriverCategory.Gold;
                                    break;
                                case nameof(EDriverCategory.Silver):
                                    category = EDriverCategory.Silver;
                                    break;
                                case nameof(EDriverCategory.Bronze):
                                case "AM":
                                    category = EDriverCategory.Bronze;
                                    break;
                                default:
                                    category = EDriverCategory.Bronze;
                                    break;
                            }
                            
                            if (!CarModelUtility.TryGetCarModelForName(fields[carModelIndex], out ECarModel carModel))
                            {
                                for (int i = 0; i < CarModelUtility.ECarModelNames.Length; i++)
                                {
                                    if (!string.Equals(fields[carModelIndex], CarModelUtility.ECarModelNames[i], StringComparison.InvariantCultureIgnoreCase)) continue;
                                    carModel = Enum.Parse<ECarModel>(CarModelUtility.ECarModelNames[i]);
                                }
                            }

                            // Do assigning magic
                            AddEntry(carNumber, false, true, carModel);
                            AddDriver(carNumber, playerId, firstName, lastName, shortName, category);
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
