using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public abstract class HtmlElement
    {
        public string Style { get; set; }
        public List<HtmlElement> Children { get; set; }

        public HtmlElement()
        {
            Children = new List<HtmlElement>();
        }

        public void Render()
        {
            OnCreated();
            OnInserted();
            OnStylesApplied();
            OnClassListApplied();
            OnTextRendered();
        }

        protected virtual void OnCreated() { Console.WriteLine("Element created"); }
        protected virtual void OnInserted() { Console.WriteLine("Element inserted"); }
        protected virtual void OnStylesApplied() { Console.WriteLine("Styles applied"); }
        protected virtual void OnClassListApplied() { Console.WriteLine("Class list applied"); }
        protected virtual void OnTextRendered() { Console.WriteLine("Text rendered"); }
    }
}
