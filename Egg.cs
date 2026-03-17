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
        static Random rnd = new Random();

        public override void Prepare()
        {
            Obtain();
            Crack();
            Cook();
            DiscardShells();
            Serve();
        }

        void Obtain() { Thread.Sleep(100); }
        void Crack() { Thread.Sleep(100); }
        void Cook() { Thread.Sleep(rnd.Next(200, 500)); }
        void DiscardShells() { Thread.Sleep(100); }
        void Serve() { Thread.Sleep(100); }
    }
}
