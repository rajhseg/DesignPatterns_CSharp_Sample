using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples
{
    internal class EventsRegisterr
    {
        public void Test()
        {
            Sample s1 = new Sample();
            s1.TapClicked += S1_TapClicked;
            s1.Click();

            Test1(S1_TapClicked);
        }

        public void Test1(OnTap tapping)
        {
            tapping.Invoke(this, new TapArgs { Name = "a" });
        }

        private void S1_TapClicked(object sender, TapArgs e)
        {
            Console.WriteLine($"{e.Name}");
        }
    }

    public class TapArgs : EventArgs
    {
        public string? Name { get; set; }
    }

    public delegate void OnTap(object sender, TapArgs e);

    public class Sample
    {
        public event OnTap? TapClicked;

        public void Click()
        {
            Console.WriteLine("clicked");
            if (TapClicked != null)
            {
                TapClicked(this, new TapArgs { Name = "testing" });
            }
        }
    }

    public class ObjectTesting: IComparable<ObjectTesting>, IEquatable<ObjectTesting>, ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public object Clone()
        {
            return (ObjectTesting)this.MemberwiseClone();
        }

        public int CompareTo(ObjectTesting? other)
        {
            if (this.Id < other.Id)
            {
                return 1;
            }
            else if(this.Id > other.Id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(ObjectTesting? other)
        {
            return this.Id == other?.Id;
        }

        public static ObjectTesting operator +(ObjectTesting obj1, ObjectTesting obj2)
        {
            return new ObjectTesting { Id = obj1.Id + obj2.Id };
        }

        public static ObjectTesting operator -(ObjectTesting obj1, ObjectTesting obj2)
        {
            return new ObjectTesting { Id = obj1.Id - obj2.Id };
        }
    }

    public class ObjectTestingComparer : IComparer<ObjectTesting>, IEqualityComparer<ObjectTesting>
    {
        public int Compare(ObjectTesting? x, ObjectTesting? y)
        {
            if(x.Id > y.Id)
            {
                return 1;
            }
            else if(x.Id < y.Id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(ObjectTesting? x, ObjectTesting? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] ObjectTesting obj)
        {
            return obj.GetHashCode();
        }
    }

    public class Rup 
    {
        public int Value { get; set; }

        public Rup(int value)
        {
            Value = value;  
        }

        public static implicit operator Rup(Eu eu)
        {
            return new Rup(eu.Value * 2);
        }

        public static explicit operator Rup(SMoney money)
        {
            return new Rup(money.Value / 3);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Eu
    {
        public int Value { get; set; }

        public Eu(int value)
        {
            Value = value;  
        }

        public static implicit operator Eu(Rup ru)
        {
            return new Eu(ru.Value / 2);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class SMoney 
    {
        public int Value { get; set; }

        public SMoney(int value)
        {
            Value = value;  
        }

        public static explicit operator SMoney(Rup v)
        {
            return new SMoney(v.Value * 3);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
