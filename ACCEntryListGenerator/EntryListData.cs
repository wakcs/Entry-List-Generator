using System;
using System.Collections.Generic;

namespace ACCEntryListGenerator
{
    [Serializable]
    public struct EntryListData
    {
        public struct DriverData
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string shortName { get; set; }
            public uint driverCategory { get; set; }
            public string playerID { get; set; }
        }

        public struct EntryData
        {
            public uint raceNumber { get; set; }
            public int forcedCarModel { get; set; }
            public byte overrideDriverInfo { get; set; }
            public byte isServerAdmin { get; set; }
            public List<DriverData> drivers { get; set; }
        }

        public List<EntryData> entries { get; set; }

        public byte forceEntryList { get; set; }
    }
}
