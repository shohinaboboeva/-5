using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Egg:MenuItem
    {
        public override void Prepare()
        {
            Obtain();
            Crack();
            CookEgg();
            DiscardShells();
            Serve();
        }

        void Obtain() { Thread.Sleep(100); }
        void Crack() { Thread.Sleep(100); }
        void CookEgg() { Thread.Sleep(200); }
        void DiscardShells() { Thread.Sleep(100); }
        void Serve() { Thread.Sleep(100); }
    }
}

