using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public void ApplyDiscount(Money discount)
        {
            int totalCents = (Price.Whole * 100 + Price.Cents) - (discount.Whole * 100 + discount.Cents);
            Price.Whole = totalCents / 100;
            Price.Cents = totalCents % 100;
        }
    }
}
