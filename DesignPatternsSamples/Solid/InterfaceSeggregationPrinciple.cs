using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Solid
{
    internal class InterfaceSeggregationPrinciple : IPrinter, IFax
    {
        public void Print(string name)
        {
            
        }

        public void Send(string content)
        {
            
        }
    }

    internal interface IPrinter
    {
        void Print(string name);
    }

    internal interface IFax
    {
        void Send(string content);
    }
}
