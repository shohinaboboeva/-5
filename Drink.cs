using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Drink:MenuItem
    {
        public override void Prepare()
        {
            Thread.Sleep(150); 
        }
    }
}
