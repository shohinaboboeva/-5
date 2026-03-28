using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class TableRequests : IEnumerable<Order>
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order) => _orders.Add(order);

        public IEnumerator<Order> GetEnumerator() =>
            _orders.OrderBy(o => o.CustomerName).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Clear() => _orders.Clear();
    }
}
