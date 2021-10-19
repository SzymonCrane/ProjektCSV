using System.Linq;
using System.IO;
using System.Text;

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
        public static StringBuilder ReadWholeCsv(string filePath)
        {
            StringBuilder arrOfStrings = new StringBuilder("");
            var lines = File.ReadLines(filePath, Encoding.UTF8);
            foreach (string line in lines)
            {
                string cleanLine = line.Replace(";", " ");
                arrOfStrings.Append(cleanLine+"\n");
            }
            return arrOfStrings;
        }
    }
}
