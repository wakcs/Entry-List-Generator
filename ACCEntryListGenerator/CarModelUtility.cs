using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCEntryListGenerator
{
    public static class CarModelUtility
    {
        public static string[] ECarModelNames = Enum.GetNames(typeof(ECarModel));

        private static Dictionary<ECarModel, string> carModelReadableNamePerEnum = new Dictionary<ECarModel, string>()
        {
            {ECarModel.RESERVED, "NONE"},
            {ECarModel.Alpine_A110_GT4_2018, "Alpine A110 GT4 (2018)"},
            {ECarModel.AMR_V12_Vantage_GT3_2013, "AMR V12 Vantage GT3 (2013)"},
            {ECarModel.AMR_V8_Vantage_2019, "AMR V8 Vantage (2019)"},
            {ECarModel.Aston_Martin_Vantage_GT4_2018, "Aston Martin Vantage GT4 (2018)"},
            {ECarModel.Audi_R8_LMS_2015, "Audi R8 LMS (2015)"},
            {ECarModel.Audi_R8_LMS_Evo_2019, "Audi R8 LMS Evo (2019)"},
            {ECarModel.Audi_R8_LMS_GT3_2022, "Audi R8 LMS GT3 Evo 2 (2022)"},
            {ECarModel.Audi_R8_LMS_GT4_2018, "Audi R8 LMS GT4 (2018)"},
            {ECarModel.Bentley_Continental_GT3_2015, "Bentley Continental GT3 (2015)"},
            {ECarModel.Bentley_Continental_GT3_2018, "Bentley Continental GT3 (2018)"},
            {ECarModel.BMW_M2_Club_Sport_Racing_2020, "BMW M2 Club Sport Racing (2020)"},
            {ECarModel.BMW_M6_GT3_2017, "BMW M6 GT3 (2017)"},
            {ECarModel.BMW_M4_GT4_2018, "BMW M4 GT4 (2018)"},
            {ECarModel.BMW_M4_GT3_2022, "BMW M4 GT3 (2022)"},
            {ECarModel.Chevrolet_Camaro_GT4_2017, "Chevrolet Camaro GT4 (2017)"},
            {ECarModel.Emil_Frey_Jaguar_G3_2012, "Emil Frey Jaguar G3 (2012)"},
            {ECarModel.Ferrari_488_Challenge_2020, "Ferrari 488 Challenge Evo (2020)"},
            {ECarModel.Ferrari_488_GT3_2018, "Ferrari 488 GT3 (2018)"},
            {ECarModel.Ferrari_488_GT3_Evo_2020, "Ferrari 488 GT3 Evo (2020)"},
            {ECarModel.Ferrari_296_GT3_2023, "Ferrari 296 GT3 (2023)"},
            {ECarModel.Ginetta_G55_GT4_2012, "Ginetta G55 GT4 (2012)"},
            {ECarModel.Honda_NSX_GT3_2017, "Honda NSX GT3 (2017)"},
            {ECarModel.Honda_NSX_GT3_Evo_2019, "Honda NSX GT3 Evo (2019)"},
            {ECarModel.KTM_X_Bow_GT4_2016, "KTM X-Bow GT4 (2016)"},
            {ECarModel.Lamborghini_Huracan_GT3_2015, "Lamborghini Huracan GT3 (2015)"},
            {ECarModel.Lamborghini_Huracan_GT3_2019, "Lamborghini Huracan GT3 Evo (2019)"},
            {ECarModel.Lamborghini_Huracan_GT3_2023, "Lamborghini Huracan GT3 Evo 2 (2023)"},
            {ECarModel.Lamborghini_Huracan_SuperTrofeo_2015, "Lamborghini Huracan SuperTrofeo (2015)"},
            {ECarModel.Lamborghini_Huracán_SuperTrofeo_2021, "Lamborghini Huracán SuperTrofeo EVO2 (2021)"},
            {ECarModel.Lexus_RC_F_GT3_2016, "Lexus RC F GT3 (2016)"},
            {ECarModel.Maserati_MC_GT4_2016, "Maserati MC GT4 (2016)"},
            {ECarModel.McLaren_570S_GT4_2016, "McLaren 570S GT4 (2016)"},
            {ECarModel.McLaren_650S_GT3_2015, "McLaren 650S GT3 (2015)"},
            {ECarModel.McLaren_720S_GT3_2019, "McLaren 720S GT3 (2019)"},
            {ECarModel.McLaren_720S_GT3_2023, "McLaren 720S GT3 Evo (2023)"},
            {ECarModel.Mercedes_AMG_GT4_2016, "Mercedes AMG GT4 (2016)"},
            {ECarModel.Mercedes_AMG_GT3_2015, "Mercedes-AMG GT3 (2015)"},
            {ECarModel.Mercedes_AMG_GT3_2020, "Mercedes-AMG GT3 (2020)"},
            {ECarModel.Nissan_GT_R_Nismo_GT3_2015, "Nissan GT-R Nismo GT3 (2015)"},
            {ECarModel.Nissan_GT_R_Nismo_GT3_2018, "Nissan GT-R Nismo GT3 (2018)"},
            {ECarModel.Porsche_718_Cayman_GT4_Clubsport_2019, "Porsche 718 Cayman GT4 Clubsport (2019)"},
            {ECarModel.Porsche_991_GT3_Cup_2017, "Porsche 991 II GT3 Cup (2017)"},
            {ECarModel.Porsche_992_GT3_Cup_2021, "Porsche 992 GT3 Cup (2021)"},
            {ECarModel.Porsche_991_GT3_R_2018, "Porsche 991 GT3 R (2018)"},
            {ECarModel.Porsche_991_GT3_R_2019, "Porsche 991 II GT3 R (2019)"},
            {ECarModel.Porsche_992_GT3_R_2023, "Porsche 992 GT3 R (2023)"},
            {ECarModel.Reiter_Engineering_R_EX_GT3_2017, "Reiter Engineering R-EX GT3 (2017)"}
        };

        public static string GetCarNameForIndex(int index)
        {
            return GetCarNameForEnum((ECarModel) index);
        }

        public static string GetCarNameForEnum(ECarModel model)
        {
            if (carModelReadableNamePerEnum.TryGetValue(model, out string name))
            {
                return name;
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool TryGetCarModelForName(string name, out ECarModel model)
        {
            foreach (KeyValuePair<ECarModel, string> kvp in carModelReadableNamePerEnum)
            {
                if (string.Equals(kvp.Value, name, StringComparison.InvariantCultureIgnoreCase))
                {
                    model = kvp.Key;
                    return true;
                }
            }

            model = ECarModel.RESERVED;
            return false;
        }

        public static string[] GetCarNames()
        {
            return carModelReadableNamePerEnum.Values.ToArray();
        }
    }
}