using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money(10, 50, "USD");
            Product product = new Product("Laptop", money);
            Warehouse warehouse = new Warehouse();
            warehouse.AddProduct(product, 5, "pcs", DateTime.Now);

            Console.WriteLine("Testing Inventory Report:");
            Console.WriteLine(warehouse.InventoryReport());

            Console.WriteLine("\nTesting Invoice Generation:");
            Console.WriteLine(Reporting.GenerateInvoice(product, 2));

            Console.WriteLine("\nApplying Discount of 2.50 USD");
            product.ApplyDiscount(new Money(2, 50, "USD"));
            Console.WriteLine("Updated Price: " + product.Price);
            Console.ReadKey();
        }
    }
}
