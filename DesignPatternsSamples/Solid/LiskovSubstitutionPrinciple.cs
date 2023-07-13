using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Solid
{
    internal class LiskovSubstitutionPrinciple
    {
        public void Process()
        {
            Person male = new Male();
            Person female = new Female();
            male.GetAttributes();
            female.GetAttributes();
        }
    }

    internal abstract class Person
    {
        public string Name { get; set; }

        public virtual string GetAttributes()
        {
            return $"Name : {Name}";
        }
    }

    internal class Male : Person
    {
        public override string GetAttributes()
        {
            return $"Male : {Name}";
        }
    }

    internal class Female : Person
    {
        public override string GetAttributes()
        {
            return $"Female : {Name}";
        }
    }
}
