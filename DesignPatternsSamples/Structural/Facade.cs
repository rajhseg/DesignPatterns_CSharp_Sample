using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    internal interface ICart
    {
        void AddToCart(IProduct product);
    }

    internal interface IProduct
    {
        string Details();
    }

    internal interface IFacade
    {
        IProduct SelectProduct();

        IList<ICart> GetCartDetaills();
    }

    internal class Cart : ICart
    {
        public void AddToCart(IProduct product)
        {
            
        }
    }

    internal class Product : IProduct
    {
        public string Details()
        {
            return "ABC";
        }
    }

    internal class Facade : IFacade
    {
        public IList<ICart> GetCartDetaills()
        {
            return new List<ICart> { new Cart() };
        }

        public IProduct SelectProduct()
        {
            return new Product();
        }
    }
}
