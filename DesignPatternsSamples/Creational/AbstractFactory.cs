using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Creational
{
    public enum Brands
    {
        Apple,
        Google
    }

    public enum Processor
    {
        I5,
        I7
    }

    public enum SystemType
    {
        Desktop,
        Laptop
    }

    public interface IBrand
    {
        Brands GetBrand();
    }

    public interface IProcessor
    {
        Processor GetProcessor();
    }

    public interface ISystemType
    {
        SystemType GetSystemType();
    }

    public class Mac : IBrand
    {
        public Brands GetBrand()
        {
            return Brands.Apple;
        }
    }

    public class Google : IBrand
    {
        public Brands GetBrand()
        {
            return Brands.Google;
        }
    }

    public class I5 : IProcessor
    {
        public Processor GetProcessor()
        {
            return Processor.I5;
        }
    }

    public class I7 : IProcessor
    {
        public Processor GetProcessor()
        {
            return Processor.I7;
        }
    }

    public class Desktop : ISystemType
    {
        public SystemType GetSystemType()
        {
            return SystemType.Desktop;
        }
    }

    public class Laptop : ISystemType
    {
        public SystemType GetSystemType()
        {
            return SystemType.Laptop;
        }
    }

    public interface ISystemFactory
    {
        IBrand BrandDetails();

        IProcessor ProcesscorDetails();

        ISystemType SystemTypeDetails();
    }

    public class AppleFactory : ISystemFactory
    {
        public IBrand BrandDetails()
        {
            return new Mac();
        }

        public IProcessor ProcesscorDetails()
        {
            return new I5();
        }

        public virtual ISystemType SystemTypeDetails()
        {
            return new Desktop();
        }
    }

    public class AppleLaptopFactory : AppleFactory
    {
        public override ISystemType SystemTypeDetails()
        {
            return new Laptop();
        }
    }

    public class GoogleFactory : ISystemFactory
    {
        public IBrand BrandDetails()
        {
            return new Google();
        }

        public IProcessor ProcesscorDetails()
        {
            return new I7();
        }

        public virtual ISystemType SystemTypeDetails()
        {
            return new Desktop();
        }
    }

    public class GoogleLaptopFactory : GoogleFactory
    {
        public override ISystemType SystemTypeDetails()
        {
            return new Laptop();
        }
    }

    internal class AbstractFactory
    {
        public static ISystemFactory GetFactory(int empcode, int factorycode)
        {
            ISystemFactory factory;
            if (factorycode == 1)
            {
                if (empcode == 1)
                {
                    factory = new AppleFactory();
                }
                else
                {
                    factory = new AppleLaptopFactory();
                }
            }
            else
            {
                if(empcode == 1)
                {
                    factory = new GoogleFactory();
                }
                else
                {
                    factory = new GoogleLaptopFactory();
                }
            }

            return factory;
        }
    }
}
