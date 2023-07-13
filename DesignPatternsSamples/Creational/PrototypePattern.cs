using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Creational
{
    internal abstract class PrototypePattern<T>
    {
        protected PrototypePattern(string name, string department)
        {
            this.Name = name;
            this.Department = department;
        }

        public string Name { get; set; }

        public string Department { get; set; }

        public abstract T Clone();
    }

    internal class PermanentEmployee : PrototypePattern<PermanentEmployee>
    {
        public int Salary { get; set; }

        public PermanentEmployee(string name, string department, int salary):base(name, department)
        {
            this.Salary = salary;
        }

        public override PermanentEmployee Clone()
        {
            return (PermanentEmployee)this.MemberwiseClone();
        }
    }

    internal class PartTimeEmployee : PrototypePattern<PartTimeEmployee>
    {
        public int Hours { get; set; }

        public PartTimeEmployee(string name, string department, int hours): base(name, department)
        {
            this.Hours = hours;
        }

        public override PartTimeEmployee Clone()
        {
            return (PartTimeEmployee)this.MemberwiseClone();
        }
    }
}
