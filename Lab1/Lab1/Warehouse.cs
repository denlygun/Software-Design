using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Warehouse
    {
        private List<(Product product, int quantity, string unit, DateTime lastDelivery)> products = new List<(Product, int, string, DateTime)>();

        public void AddProduct(Product product, int quantity, string unit, DateTime lastDelivery)
        {
            products.Add((product, quantity, unit, lastDelivery));
        }

        public string InventoryReport()
        {
            string report = "--- Inventory Report ---\n";
            foreach (var item in products)
            {
                report += $"{item.product.Name} - {item.quantity} {item.unit} - {item.product.Price}\n";
            }
            return report;
        }
    }
}
