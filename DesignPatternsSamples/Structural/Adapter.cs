using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface IEmployee
    {
        string GetDetails(int indent);
    }

    public class Employee: IEmployee
    {
        public int Salary { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string GetDetails(int indent)
        {
            return "+" + new string('-', indent) + this.Name;
        }
    }

    public class EmployeeSystem
    {
        public void Process(List<Employee> emps)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in emps)
            {
                sb.Append(item.Name);
            }
        }
    }

    public class EmployeeAdapter
    {
        static EmployeeSystem system = new EmployeeSystem();

        public static void Process(string[,] emps)
        {
            List<Employee> emplist = new List<Employee>();

            for (int i = 0; i < emps.GetLength(0); i++)
            {

                var name = emps[i, 0];
                var age = emps[i, 1];
                var salary = emps[i, 2];

                emplist.Add(new Employee { Name = name, Age = int.Parse(age), Salary = int.Parse(salary) });

            }

            system.Process(emplist);            
        }
    }
}
