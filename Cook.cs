using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Cook
    {
        private SemaphoreSlim semaphore;

        public Cook(int count)
        {
            semaphore = new SemaphoreSlim(count);
        }

        public async Task ProcessAsync(IEnumerable<MenuItem> items)
        {
            await semaphore.WaitAsync();

            try
            {
                foreach (var item in items)
                {
                    item.Prepare();
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
