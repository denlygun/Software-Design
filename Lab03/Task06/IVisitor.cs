using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public interface IVisitor
    {
        void VisitDiv(DivElement div);
        void VisitSpan(SpanElement span);
    }
}
