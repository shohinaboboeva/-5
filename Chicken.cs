using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Chicken:MenuItem
    {
        public override void Prepare()
        {
            Obtain();
            CutUp();
            CookChicken();
            Serve();
        }

        void Obtain() { Thread.Sleep(200); }
        void CutUp() { Thread.Sleep(200); }
        void CookChicken() { Thread.Sleep(500); }
        void Serve() { Thread.Sleep(100); }
    }
}

