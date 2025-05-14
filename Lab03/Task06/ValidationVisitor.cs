using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class ValidationVisitor : IVisitor
    {
        public void VisitDiv(DivElement div)
        {
            Console.WriteLine("Validating Div...");
        }

        public void VisitSpan(SpanElement span)
        {
            Console.WriteLine("Validating Span...");
        }
    }
}
