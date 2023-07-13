using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface IPaymentSystem
    {
        void Transact(int amount);
    }

    public class NetBanking : IPaymentSystem
    {
        public void Transact(int amount)
        {
            
        }
    }

    public class UpiPayment : IPaymentSystem
    {
        public void Transact(int amount)
        {
            
        }
    }

    public abstract class Bank
    {
        public IPaymentSystem PaymentSystem { get; set; }

        public abstract void Credit(int amount);
    }

    public class ABank : Bank
    {
        public override void Credit(int amount)
        {
            PaymentSystem.Transact(amount);
        }
    }
}
