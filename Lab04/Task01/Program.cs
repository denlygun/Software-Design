using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    abstract class SupportHandler
    {
        protected SupportHandler nextHandler;

        public void SetNext(SupportHandler handler)
        {
            nextHandler = handler;
        }

        public abstract bool HandleRequest(int option);
    }

    class Level1Support : SupportHandler
    {
        public override bool HandleRequest(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("Питання вирішено на рівні 1: Загальні питання.");
                return true;
            }
            else if (nextHandler != null)
            {
                return nextHandler.HandleRequest(option);
            }
            return false;
        }
    }

    class Level2Support : SupportHandler
    {
        public override bool HandleRequest(int option)
        {
            if (option == 2)
            {
                Console.WriteLine("Питання вирішено на рівні 2: Проблеми з програмним забезпеченням.");
                return true;
            }
            else if (nextHandler != null)
            {
                return nextHandler.HandleRequest(option);
            }
            return false;
        }
    }

    class Level3Support : SupportHandler
    {
        public override bool HandleRequest(int option)
        {
            if (option == 3)
            {
                Console.WriteLine("Питання вирішено на рівні 3: Проблеми з підключенням до мережі.");
                return true;
            }
            else if (nextHandler != null)
            {
                return nextHandler.HandleRequest(option);
            }
            return false;
        }
    }

    class Level4Support : SupportHandler
    {
        public override bool HandleRequest(int option)
        {
            if (option == 4)
            {
                Console.WriteLine("Питання вирішено на рівні 4: Апартне забезпечення.");
                return true;
            }
            else
            {
                Console.WriteLine("Жоден рівень не зміг вирішити проблему.");
                return false;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SupportHandler level1 = new Level1Support();
            SupportHandler level2 = new Level2Support();
            SupportHandler level3 = new Level3Support();
            SupportHandler level4 = new Level4Support();

            level1.SetNext(level2);
            level2.SetNext(level3);
            level3.SetNext(level4);

            bool resolved = false;

            while (!resolved)
            {
                Console.WriteLine("\nВітаємо в службі підтримки. Оберіть тип питання:");
                Console.WriteLine("1 - Загальні питання");
                Console.WriteLine("2 - Програмне забезпечення");
                Console.WriteLine("3 - Мережеві проблеми");
                Console.WriteLine("4 - Апаратне забезпечення");
                Console.Write("Ваш вибір: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    resolved = level1.HandleRequest(option);

                    if (!resolved)
                    {
                        Console.WriteLine("Спробуйте ще раз...");
                    }
                }
                else
                {
                    Console.WriteLine("Некоректне введення. Спробуйте ще раз.");
                }
            }

            Console.WriteLine("\nДякуємо за звернення до служби підтримки!");
            Console.ReadKey();
        }
    }
}
