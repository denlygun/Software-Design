using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class DepthIterator
    {
        private Stack<HtmlElement> stack;

        public DepthIterator(HtmlElement root)
        {
            stack = new Stack<HtmlElement>();
            stack.Push(root);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public HtmlElement Next()
        {
            HtmlElement current = stack.Pop();
            for (int i = current.Children.Count - 1; i >= 0; i--)
            {
                stack.Push(current.Children[i]);
            }
            return current;
        }
    }

}
