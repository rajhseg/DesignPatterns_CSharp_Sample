using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Creational
{
    internal class FactoryMethod
    {
        public static IAnimal GetInstance(int code)
        {
            IAnimal obj;

            switch (code)
            {
                case 1:
                    obj = new Dog("Dog");
                    break;
                case 2:
                    obj = new Cat("Cat");
                    break;
                default:
                    obj = new Cat("Cat2");
                    break;
            }

            return obj;
        }
    }

    public interface IAnimal
    {
      string Name { get; set; }
    }

    public class Dog : IAnimal
    {
        public string Name { get; set; }

        public Dog(string name)
        {
            this.Name = name;
        }
    }

    public class Cat : IAnimal
    {
        public string Name { get; set; }

        public Cat(string name) 
        {
            this.Name = name;
        }
    }
}
