using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    internal class Manager : IEmployee
    {
        public string Name { get; set; }

        private List<IEmployee> Employees { get; set; }

        public Manager(string name)
        {
            this.Name = name;
            Employees = new List<IEmployee>();
        }

        public void AddSubOrdinate(IEmployee employee)
        {
            Employees.Add(employee);
        }

        public string GetDetails(int indent)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("+" + new string('-', indent) + this.Name);
            
            foreach (var item in Employees)
            {
                builder.AppendLine(item.GetDetails(indent+1));
            }

            return builder.ToString();
        }
    }    
}
