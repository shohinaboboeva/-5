using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_5
{
    internal class Order : IEnumerable<MenuItem>
    {
        public string CustomerName { get; set; }
        public List<MenuItem> Items { get; } = new List<MenuItem>();
        public Guid OrderId { get; } = Guid.NewGuid(); 

        public void Add(MenuItem item)
        {
            item.CustomerName = this.CustomerName;
            Items.Add(item);
        }

        public IEnumerator<MenuItem> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string GetSummary()
        {
            var drinkNames = Items.OfType<Drink>().Select(d => d.Name);
            string drinksText = drinkNames.Any() ? string.Join(", ", drinkNames) : "no drinks";

            int eggs = Items.Count(x => x is Egg);
            int chicken = Items.Count(x => x is Chicken);

            return $"{CustomerName} ordered {drinksText}, {eggs} egg, {chicken} chicken";
        }
    }
}
