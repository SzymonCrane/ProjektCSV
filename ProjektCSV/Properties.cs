using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSV
{
    public class Properties : Interface1
    {
        public int Id { get; set; }
        public Properties(int id)
        {
            Id = id;
        }
        public void ShowId()
        {
            Console.Write(Id);
        }
    }
}
