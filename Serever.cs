using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Serever
    {
        private TableRequests table;
        private object locker = new object();

        public Serever(TableRequests t)
        {
            table = t;
        }


        public async Task SendAsync(Cook cook, Action<string> log)
        {
            IEnumerable<MenuItem> items;

            lock (locker)
            {
                items = table; 
            }

            var cookTask = Task.Run(async () =>
            {
                await cook.ProcessAsync(items);
            });

            await cookTask;

            await Task.Run(() =>
            {
                lock (locker)
                {
                    foreach (var item in items)
                    {
                        log($"Served: {item.CustomerName} - {item.GetType().Name}");
                    }
                }
            });
        }
    }
}
