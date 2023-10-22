using System;
using ACCEntryListGenerator.Properties;

namespace ACCEntryListGenerator
{
    public static class CsvEntryListGenerator
    {
        public static bool DoesFieldExistInSetting(string field, string setting)
        {
            string[] settingSeparatedByComma = setting.Split(',');
            for (int i = 0; i < settingSeparatedByComma.Length; i++)
            {
                if (string.Equals(settingSeparatedByComma[i], field, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static EDriverCategory GetCategoryFromCustomSetting(string customCategoryName)
        {
            if (DoesFieldExistInSetting(customCategoryName, Settings.Default.categoryPropertyPlatinumAlias)) return EDriverCategory.Platinum;
            if (DoesFieldExistInSetting(customCategoryName, Settings.Default.categoryPropertyGoldAlias)) return EDriverCategory.Gold;
            if (DoesFieldExistInSetting(customCategoryName, Settings.Default.categoryPropertySilverAlias)) return EDriverCategory.Silver;
            if (DoesFieldExistInSetting(customCategoryName, Settings.Default.categoryPropertyBronzeAlias)) return EDriverCategory.Bronze;
            return EDriverCategory.Bronze;
        }
    }
}