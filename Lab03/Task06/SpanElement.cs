using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class SpanElement : HtmlElement, IVisitable
    {
        protected override void OnCreated() { Console.WriteLine("Span created"); }
        protected override void OnInserted() { Console.WriteLine("Span inserted"); }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitSpan(this);
        }
    }
}
