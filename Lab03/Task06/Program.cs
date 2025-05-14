using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шаблонний метод");
            HtmlElement div = new DivElement();
            div.Render();

            Console.WriteLine("\nІтератор (в глибину)");
            DivElement root = new DivElement();
            SpanElement child1 = new SpanElement();
            DivElement child2 = new DivElement();
            root.Children.Add(child1);
            root.Children.Add(child2);

            DepthIterator depthIterator = new DepthIterator(root);
            while (depthIterator.HasNext())
            {
                HtmlElement el = depthIterator.Next();
                Console.WriteLine("Відвідано: " + el.GetType().Name);
            }

            Console.WriteLine("\nІтератор");
            BreadthIterator breadthIterator = new BreadthIterator(root);
            while (breadthIterator.HasNext())
            {
                HtmlElement el = breadthIterator.Next();
                Console.WriteLine("Відвідано: " + el.GetType().Name);
            }

            Console.WriteLine("\nКоманда: додати елемент");
            SpanElement newChild = new SpanElement();
            AddElementCommand addCmd = new AddElementCommand(root, newChild);
            addCmd.Execute();
            Console.WriteLine("Кількість дітей після додавання: " + root.Children.Count);
            addCmd.Undo();
            Console.WriteLine("Кількість дітей після скасування: " + root.Children.Count);

            Console.WriteLine("\nКоманда: змінити стиль");
            root.Style = "color: red;";
            ChangeStyleCommand styleCmd = new ChangeStyleCommand(root, "color: blue;");
            styleCmd.Execute();
            Console.WriteLine("Новий стиль: " + root.Style);
            styleCmd.Undo();
            Console.WriteLine("Відновлений стиль: " + root.Style);

            Console.WriteLine("\nПатерн Стан");
            Editor editor = new Editor();
            editor.SetState(new ViewState());
            editor.Render();
            editor.SetState(new EditState());
            editor.Render();
            editor.SetState(new PreviewState());
            editor.Render();

            Console.WriteLine("\nВідвідувач: валідація");
            IVisitable visitableDiv = new DivElement();
            IVisitable visitableSpan = new SpanElement();
            ValidationVisitor validator = new ValidationVisitor();
            visitableDiv.Accept(validator);
            visitableSpan.Accept(validator);

            Console.WriteLine("\nВідвідувач: статистика");
            StatsVisitor statsVisitor = new StatsVisitor();
            DivElement complexDiv = new DivElement();
            complexDiv.Children.Add(new SpanElement());
            complexDiv.Children.Add(new DivElement());

            complexDiv.Accept(statsVisitor);
            Console.WriteLine("Div'ів: " + statsVisitor.DivCount + ", Span'ів: " + statsVisitor.SpanCount);

            Console.ReadKey();
        }
    }
}
