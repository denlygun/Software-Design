using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class TextDocument
    {
        public string Content { get; set; }

        public TextDocument(string content = "")
        {
            Content = content;
        }

        public void Append(string text)
        {
            Content += text;
        }

        public override string ToString()
        {
            return Content;
        }

        public DocumentMemento Save()
        {
            return new DocumentMemento(Content);
        }

        public void Restore(DocumentMemento memento)
        {
            Content = memento.Content;
        }
    }

    public class DocumentMemento
    {
        public string Content { get; }

        public DocumentMemento(string content)
        {
            Content = content;
        }
    }

    public class TextEditor
    {
        private TextDocument _document;
        private Stack<DocumentMemento> _history = new Stack<DocumentMemento>();

        public TextEditor()
        {
            _document = new TextDocument();
        }

        public void Type(string text)
        {
            _history.Push(_document.Save()); 
            _document.Append(text);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var memento = _history.Pop();
                _document.Restore(memento);
            }
            else
            {
                Console.WriteLine("Немає станів для скасування.");
            }
        }

        public void Show()
        {
            Console.WriteLine($"Документ: \"{_document}\"");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            TextEditor editor = new TextEditor();

            editor.Type("Привіт");
            editor.Show();

            editor.Type(", всім!");
            editor.Show();
            
            editor.Type(" мене звати Лигун Денис!");
            editor.Show();

            editor.Undo(); 
            editor.Show();

            editor.Undo(); 
            editor.Show();

            editor.Undo();
            editor.Show();

            editor.Undo(); 
            Console.ReadKey();
        }
    }
}
