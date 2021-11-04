using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjektCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. In new files create two classes: House (properties: Id - int, Surface - int, Name - string, IsFlat - bool, Description - string), Human (Id - int, BirthDate - DateTime, Height - byte)
            In Houses description use some commas and watch out for them as it is a common csv separator and may cause you some trouble.
            2. Create two lists with at least 5 elements each, one with Houses and one with Humans
            3. Create two csv files and append to them the right text (check in Excel if it works)
            4. Try to extract the data from the files - two new variables that will have exactly the same as the ones created manually in the second step
            */

            var houses = new List<House>() {
                new House(1, 100, "Stanowski", true, "House has two separate floors, upstairs there is a bedroom and a toilet, downstairs family has living room, kitchen and small garderobe"),
                new House(2, 240, "Borek", false, "This house has also two floors, small garden outside and inside there is 3 bedrooms, huge living room and nice - modern kitchen."),
                new House(3, 140, "Pol", true, "This house has bald floors"),
                new House(4, 280, "Boniek", false, "This house is simply - TOP"),
                new House(5, 50, "Lewandowski", true, "This house has golden balls around the living room")
            };

            var humans = new List<Human>() {
                new Human(1, new DateTime(1980, 7, 21), 185),
                new Human(2, new DateTime(1986, 4, 7), 176),
                new Human(3, new DateTime(2000, 8, 21), 200),
                new Human(4, new DateTime(2004, 2, 20), 145),
                new Human(5, new DateTime(1995, 11, 11), 198)
            };

            var strFilePath = @"C:\Users\Szymon\source\repos\ProjektCSV\ProjektCSV\";
            var humanFileName = "humans.csv";
            var houseFileName = "houses.csv";
            // Jak z dowolnego obiektu wyciągnać listę jego właściwości. - ekspresja 'nameof'

            SaveDataToFile(houses, humans, strFilePath, humanFileName, houseFileName);
            ReadDataFromFile(strFilePath, houseFileName);
        }

        private static void ReadDataFromFile(string strFilePath, string houseFileName)
        {
            var file = new StreamReader(strFilePath + houseFileName);

            string line;
            //  string header = (string)file.ReadLine().Skip(0);
            var readRowsList = new List<string> { };
            do
            {
                line = file.ReadLine();
                readRowsList.Add(line);

            } while (line != null);
            readRowsList = readRowsList.Skip(1).ToList();
            readRowsList.Remove(null);
            readRowsList.Remove("");

            var houseList = new List<House>();
            foreach (string row in readRowsList)
            {
                var rowValuesList = row.Split(";");
                var house = new House(Int32.Parse(rowValuesList[0]), Int32.Parse(rowValuesList[1]), rowValuesList[2], Boolean.Parse(rowValuesList[3]), rowValuesList[4]);
                houseList.Add(house);
                house.GetProps();
            }
        }

        private static void SaveDataToFile(List<House> houses, List<Human> humans, string strFilePath, string humanFileName, string houseFileName)
        {
            var houseColumnNamesString = CsvTools.GetClassPropertiesString<House>();
            var humanColumnNamesString = CsvTools.GetClassPropertiesString<Human>();

            var humanValues = new StringBuilder("");
            foreach (var human in humans)
            {
                humanValues.Append($"{human.Id};{human.BirthDay};{human.Height};\n");
            }

            using (StreamWriter fileHuman = new StreamWriter(strFilePath + humanFileName, false))
            {
                fileHuman.WriteLine(humanColumnNamesString);
                fileHuman.WriteLine(humanValues);
            }
            // Wyseparować do osobnych klas/metod resztę kodu np. do SaveDataToCsv()


            var readCSV = CsvTools.ReadCsv(strFilePath + houseFileName);
            //Console.WriteLine(readCSV);

            //TODO
            // Zrobić automatyczne sczytywanie z listy nazw kolumn i ich właściwości, np. zamiast house.ID w linii 72

            var houseValues = new StringBuilder("");
            foreach (var house in houses)
            {
                houseValues.Append($"{house.Id};{house.Surface};{house.Name};{house.IsFlat};{house.Description};\n");
            }
            using (StreamWriter rdfile = new StreamWriter(strFilePath + houseFileName, false)) // true = dodaj | false = nadpisz
            {
                rdfile.WriteLine(houseColumnNamesString);
                rdfile.WriteLine(houseValues);
            }
        }
    }
}
