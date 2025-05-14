using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class ChangeStyleCommand
    {
        private HtmlElement element;
        private string newStyle;
        private string oldStyle;

        public ChangeStyleCommand(HtmlElement element, string newStyle)
        {
            this.element = element;
            this.newStyle = newStyle;
            this.oldStyle = element.Style;
        }

        public void Execute()
        {
            element.Style = newStyle;
        }

        public void Undo()
        {
            element.Style = oldStyle;
        }
    }
}
