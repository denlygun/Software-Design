using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class AddElementCommand
    {
        private HtmlElement parent;
        private HtmlElement child;

        public AddElementCommand(HtmlElement parent, HtmlElement child)
        {
            this.parent = parent;
            this.child = child;
        }

        public void Execute()
        {
            parent.Children.Add(child);
        }

        public void Undo()
        {
            parent.Children.Remove(child);
        }
    }
}
