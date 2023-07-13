using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples
{
    public class AsyncPrograms
    {
        public int  Number { get;set; }

        public volatile List<string> coll = new List<string>();

        AutoResetEvent resetEvent = new AutoResetEvent(false);

        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 5);

        public void IncNum()
        {                       
            resetEvent.Set();
            resetEvent.WaitOne();
            Number++;
            coll.Add("a"); 
            Console.WriteLine(Number.ToString());   
            resetEvent.Reset();
        }

        public void DecrementNumber()
        {
            try
            {
                semaphoreSlim.Wait();
                Number++;
                Console.WriteLine(Number);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async Task DecNum()
        {
            await Task.Run(() => { Number--; Console.WriteLine(Number.ToString()); });
        }
    }
}
