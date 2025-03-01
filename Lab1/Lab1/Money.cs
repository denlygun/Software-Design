using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Money
    {
        public int Whole { get; set; }
        public int Cents { get; set; }
        public string Currency { get; set; }

        public Money(int whole, int cents, string currency)
        {
            Whole = whole;
            Cents = cents;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{Whole}.{Cents:D2} {Currency}";
        }
    }
}
