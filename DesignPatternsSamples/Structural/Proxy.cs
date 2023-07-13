using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface IPerson
    {
        void Walk();
    }

    public class Person : IPerson
    {
        private Employee employee;

        public Person(Employee emp)
        {
            this.employee = emp;
        }

        public void Walk()
        {
            string detail = $"Name: {this.employee.Name}";
        }
    }

    internal class PersonProxy : IPerson
    {
        private Employee employee;

        public PersonProxy(Employee emp)
        {
            this.employee = emp;
        }

        public void Walk()
        {
            Person person = new Person(employee);
            person.Walk();
        }
    }
}
