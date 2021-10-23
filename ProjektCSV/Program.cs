using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
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

            List<House> houses = new List<House>() {
                new House(1, 100, "Stanowski", true, "House has two separate floors, upstairs there is a bedroom and a toilet, downstairs family has living room, kitchen and small garderobe"),
                new House(2, 240, "Borek", false, "This house has also two floors, small garden outside and inside there is 3 bedrooms, huge living room and nice - modern kitchen."),
                new House(3, 140, "Pol", true, "This house has bald floors"),
                new House(4, 280, "Boniek", false, "This house is simply - TOP"),
                new House(5, 50, "Lewandowski", true, "This house has golden balls around the living room")
            };
            List<Human> humans = new List<Human>() {
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
            Console.WriteLine(readCSV);
            
            using(StreamReader file = new StreamReader(strFilePath+houseFileName))
            {
                
                string? line;
                string header = line.Skip(1);
                var newList = new List<House>(header);
                while(line != null)
                {
                    newList.Append(line);
                }
            }
            
            //TODO
            // Zrobić automatyczne sczytywanie z listy nazw kolumn i ich właściwości, np. zamiast house.ID w linii 72
 
            var houseValues = new StringBuilder("");
            foreach (var house in houses)
            {
                houseValues.Append($"{house.Id};{house.Name};{house.Surface};{house.IsFlat};{house.Description};\n");
            }
            using (StreamWriter file = new StreamWriter(strFilePath+houseFileName, false)) // true = dodaj | false = nadpisz
            { 
                file.WriteLine(houseColumnNamesString);
                file.WriteLine(houseValues);
            }
        }

    }
}
