using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Serever
    {

        private readonly object _serverLock = new object();

        public Task ProcessOrderAsync(Cook cook, Order order, Action<string> log)
        {
            return cook.PrepareAllAsync(order.Items.ToList())
                .ContinueWith(ant => {
                    lock (_serverLock)
                    {
                        Thread.Sleep(500);

                        string summary = order.GetSummary();
                        log($"Server delivered: {summary}");
                    }
                }, TaskScheduler.Default); 
        }
    }
}
    

