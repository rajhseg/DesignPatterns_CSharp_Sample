using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Models
{
    public class Emp
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public Dep? Department { get; set; }

        public List<Book> Books { get; set; }

        public List<Guid> Guids { get; set; }

        public Collection<String> Samples { get; set; }

        public Collection<Book> WrittenBooks { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }
    }
    public class Dep
    {
        public int DepId { get; set; }

        public string? Name { get; set; }
    }
}
