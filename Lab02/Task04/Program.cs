using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Virus : ICloneable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string type, int age, double weight)
        {
            Name = name;
            Type = type;
            Age = age;
            Weight = weight;
            Children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public object Clone()
        {
            Virus clone = new Virus(Name, Type, Age, Weight);
            foreach (var child in Children)
            {
                clone.Children.Add((Virus)child.Clone());
            }
            return clone;
        }

        public void Display(int level = 0)
        {
            Console.WriteLine(new string('-', level * 2) + $"> {Name} ({Type}), Вік: {Age}, Вага: {Weight}");
            foreach (var child in Children)
            {
                child.Display(level + 1);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Virus parent = new Virus("Alpha", "COVID-19", 3, 0.1);
            Virus child1 = new Virus("Beta", "COVID-19", 2, 0.08);
            Virus child2 = new Virus("Gamma", "COVID-19", 1, 0.05);
            parent.AddChild(child1);
            parent.AddChild(child2);

            Virus grandChild = new Virus("Delta", "COVID-19", 1, 0.03);
            child1.AddChild(grandChild);

            Console.WriteLine("Оригінальне сімейство:");
            parent.Display();

            Virus clonedParent = (Virus)parent.Clone();
            Console.WriteLine("\nКлоноване сімейство:");
            clonedParent.Display();
            Console.ReadKey();
        }
    }

}
