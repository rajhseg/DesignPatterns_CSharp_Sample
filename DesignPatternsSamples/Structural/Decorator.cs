using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface ICar
    {
        string Name { get; }

        int GetPrice();
    }

    public class Car : ICar
    {
        public string Name { get; set; }

        public Car(string name)
        {
            this.Name = name;
        }

        public int GetPrice()
        {
            return 5000;
        }
    }

    internal class CarDecorator 
    {
        public ICar car; 
        
        public CarDecorator(ICar car)
        {
            this.car = car;
        }
       
        public int GetOfferPrice()
        {
            int price = car.GetPrice();
            return price - 1000;
        }
    }
}
