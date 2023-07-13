using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Models
{
    public class CopyModel1
    {
        [MapColumn(typeof(CopyModel2), "Id")]
        public int Id { get; set; }

        [MapColumn(typeof(CopyModel2), "Name")]
        public string? ModelName { get; set; }

        public int Age { get; set; }

        [MapColumn(typeof(CopyModel2), "Persons")]
        public List<Person>? PersonsList { get; set; }
    }
}
