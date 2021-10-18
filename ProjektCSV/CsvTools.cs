using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSV
{
    public static class CsvTools
    {
        public static string GetClassPropertiesString<T>()
        {
            var houseColumnNames = typeof(T).GetProperties().Select(prop => prop.Name);
            var houseColumnNamesString = string.Join(";", houseColumnNames);


            return houseColumnNamesString;
        }
    }
}
