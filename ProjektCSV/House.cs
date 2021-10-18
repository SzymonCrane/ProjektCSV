using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSV
{
    public class House : Properties
    {
        public int Id { get; set; }
        public int Surface { get; set; }
        public string Name { get; set; }
        public bool IsFlat { get; set; }
        public string Description { get; set; }

        public House(int id, int surface, string name, bool isFlat, string description) : base (id)
        {
            Id = id;
            Surface = surface;
            Name = name;
            IsFlat = isFlat;
            Description = description;
        }
        public void ShowId()
        {
            Console.WriteLine(Id);
        }
    }
}
