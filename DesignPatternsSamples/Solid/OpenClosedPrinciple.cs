using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Solid
{
    internal class OpenClosedPrinciple
    {
        public void Calculate()
        {
            Shape[] shapes = new Shape[2]; 
            shapes[0] = new Rectangle();
            shapes[1] = new Square();

            foreach (var item in shapes)
            {
                item.CalculateArea();
            }
        }
    }

    internal abstract class Shape
    {
        protected int height;
        protected int width;

        protected abstract double GetArea();

        public double CalculateArea()
        {
            return GetArea();
        }
    }

    internal class Rectangle : Shape
    {
        protected override double GetArea()
        {
            return width * height;
        }
    }

    internal class Square : Shape
    {
        protected override double GetArea()
        {
            return width * width * width * width;
        }
    }
}
