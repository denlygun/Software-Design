using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Reporting
    {
        public static string GenerateInvoice(Product product, int quantity)
        {
            double totalPrice = quantity * (product.Price.Whole + product.Price.Cents / 100.0);
            return $"Invoice: {product.Name}, Quantity: {quantity}, Total: {totalPrice:F2} {product.Price.Currency}";
        }
    }
}
