using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false)]
    internal class ColumnProp : Attribute
    {
        public string Name { get; set; }

        public string PropertyName { get; set; }

        public ColumnProp(string name, [CallerMemberName] string propertyname = "")
        {
            this.PropertyName = propertyname;
            this.Name = name;
        }
    }
}
