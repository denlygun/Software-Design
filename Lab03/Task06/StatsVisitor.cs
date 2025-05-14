using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class StatsVisitor : IVisitor
    {
        public int DivCount { get; private set; }
        public int SpanCount { get; private set; }

        public void VisitDiv(DivElement div)
        {
            DivCount++;
            foreach (HtmlElement child in div.Children)
            {
                IVisitable visitable = child as IVisitable;
                if (visitable != null)
                {
                    visitable.Accept(this);
                }
            }
        }

        public void VisitSpan(SpanElement span)
        {
            SpanCount++;
        }
    }
}
