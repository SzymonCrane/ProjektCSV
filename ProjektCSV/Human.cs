using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSV
{
    public class Human : Properties
    {
        public int Id { get; set; }
        public DateTime BirthDay { get; set; }
        public byte Height { get; set; }

        public Human(int id, DateTime birthday, byte height) : base(id)
        {
            Id = id;
            BirthDay = birthday;
            Height = height;
        }
        public void ShowBirthday()
        {
            Console.Write(BirthDay);
        }
    }
}
