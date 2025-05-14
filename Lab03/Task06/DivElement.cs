using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class DivElement : HtmlElement, IVisitable
    {
        protected override void OnCreated() { Console.WriteLine("Div created"); }
        protected override void OnInserted() { Console.WriteLine("Div inserted"); }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitDiv(this);
        }
    }
}
