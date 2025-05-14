using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class Editor
    {
        private IEditorState state;

        public void SetState(IEditorState state)
        {
            this.state = state;
        }

        public void Render()
        {
            if (state != null)
                state.Render();
        }
    }
}
