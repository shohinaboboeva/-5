using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class TableRequests:IEnumerable<MenuItem>
    {
        private Dictionary<string, List<MenuItem>> data = new Dictionary<string, List<MenuItem>>();

        public void Add<T>(string customer) where T : MenuItem, new()
        {
            if (!data.ContainsKey(customer))
                data[customer] = new List<MenuItem>();

            data[customer].Add(new T { CustomerName = customer });
        }

        public List<MenuItem> this[string customer]
        {
            get => data[customer];
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            var snapshot = data
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.ToList()
                );

            foreach (var c in snapshot)
                foreach (var item in c.Value.Where(x => x is Drink))
                    yield return item;

            foreach (var c in snapshot)
                foreach (var item in c.Value.Where(x => !(x is Drink)))
                    yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<string> Customers =>
            data.Keys.OrderBy(x => x);
    }
}
