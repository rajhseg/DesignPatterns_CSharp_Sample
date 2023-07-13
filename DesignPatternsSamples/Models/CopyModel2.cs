using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Models
{
    internal class CopyModel2
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Person> Persons { get; set; }
    }
}
