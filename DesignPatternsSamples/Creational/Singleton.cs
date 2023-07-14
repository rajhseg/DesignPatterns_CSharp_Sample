using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Creational
{
    public class Singleton
    {
        private static Singleton _instance;
        private static Object _obj = new object();

        private Singleton() { }

        public static Singleton Instance()
        {
            lock (_obj)
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        _instance = new Singleton();
                    }
                } 

                return _instance;
            }
        }
    }
}
