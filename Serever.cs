using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Serever
    {

        public Task ProcessOrderAsync(Cook cook, List<MenuItem> items, Action<string> log)
        {
            return cook.PrepareAllAsync(items)
                .ContinueWith(ant => {
                    foreach (var item in items)
                    {
                        log($"Served: {item.CustomerName} - {item.GetType().Name}");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
    

