using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    internal class FlyWeightFactory
    {
        Dictionary<string, IFlyWeight> flyWeightDictionary = new Dictionary<string, IFlyWeight>();
        public FlyWeightFactory()
        {
            flyWeightDictionary = new Dictionary<string, IFlyWeight> { { "A", new FlyWeightAB() } };
        }

        public IFlyWeight GetInstance(string key)
        {
            if (flyWeightDictionary.ContainsKey(key))
            {
                return flyWeightDictionary[key];
            }
            else
            {
                var fc = new FlyWeightCD();
                flyWeightDictionary.Add(key, fc);
                return fc;
            }
        }
    }

    internal interface IFlyWeight
    {
        void AB();
    }

    internal class FlyWeightAB : IFlyWeight
    {
        public void AB()
        {
            
        }
    }

    internal class FlyWeightCD : IFlyWeight
    {
        public void AB()
        {
            
        }
    }
}
