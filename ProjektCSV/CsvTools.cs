using System.Linq;

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
