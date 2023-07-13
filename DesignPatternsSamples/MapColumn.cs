using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapColumn : Attribute
    {
        public Type CopyToType { get; set; }

        public string CopyPropertyName { get; set; }

        public string PropertyName { get; set; }

        public MapColumn(Type copyToType, string copyPropertyName, [CallerMemberName] string propertyName = "")
        {
            CopyPropertyName = copyPropertyName;
            PropertyName = propertyName;
            CopyToType = copyToType;
        }
    }
}
