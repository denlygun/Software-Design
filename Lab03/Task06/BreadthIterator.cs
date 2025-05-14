using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class BreadthIterator
    {
        private Queue<HtmlElement> queue;

        public BreadthIterator(HtmlElement root)
        {
            queue = new Queue<HtmlElement>();
            queue.Enqueue(root);
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }

        public HtmlElement Next()
        {
            HtmlElement current = queue.Dequeue();
            foreach (HtmlElement child in current.Children)
            {
                queue.Enqueue(child);
            }
            return current;
        }
    }
}
