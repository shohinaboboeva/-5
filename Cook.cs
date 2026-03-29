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
        private SemaphoreSlim _semaphore;
        public Cook(int capacity) => _semaphore = new SemaphoreSlim(capacity);

        public async Task PrepareAllAsync(List<MenuItem> items)
        {
            await _semaphore.WaitAsync(); 
            try
            {
                await Task.Run(() =>
                {
                    foreach (var item in items)
                    {
                        item.Prepare();
                    }
                });
            }
            finally
            {
                _semaphore.Release(); 
            }
        }
    }
}
