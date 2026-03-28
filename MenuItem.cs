using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal abstract class MenuItem
    {
        public string CustomerName { get; set; }
        public Guid OrderId { get; set; } = Guid.NewGuid(); 
        public abstract void Prepare();
    }
}
