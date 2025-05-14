using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class ViewState : IEditorState
    {
        public void Render()
        {
            Console.WriteLine("Rendering in View Mode");
        }
    }
}
