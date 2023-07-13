using DesignPatternsSamples.Structural;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Behaviour
{
    internal class EmployeeList : IEnumerable<string>
    {
        public List<Employee> emps = new List<Employee>();
        
        public EmployeeList()
        {

        }

        public void Add(Employee emp)
        {
            emps.Add(emp);
        }

        public IEnumerator GetEnumerator()
        {            
            return new EmployeeEnumerator(this);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return new EmployeeEnumerator(this);
        }
    }

    internal class EmployeeEnumerator : IEnumerator<string>
    {
        private EmployeeList empsList;
        private int count = 0;

        public EmployeeEnumerator(EmployeeList employees)
        {
            this.empsList = employees;
        }

        public string Current => $"Name: {this.empsList.emps[count-1].Name}, Age:{this.empsList.emps[count-1].Age}";

        object IEnumerator.Current => $"Name: {this.empsList.emps[count-1].Name}, Age:{this.empsList.emps[count-1].Age}";

        public void Dispose()
        {
            this.empsList.emps = new List<Employee>();
        }

        public bool MoveNext()
        {
            count++;
            return count <= empsList.emps.Count();
        }

        public void Reset()
        {
            count = 0;
        }
    }
}
