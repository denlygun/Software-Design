using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    interface ILaptop
    {
        void ShowInfo();
    }

    interface INetbook
    {
        void ShowInfo();
    }

    interface IEBook
    {
        void ShowInfo();
    }

    interface ISmartphone
    {
        void ShowInfo();
    }
    class IProneLaptop : ILaptop
    {
        public void ShowInfo() => Console.WriteLine("IProne Laptop: потужний та стильний!");
    }

    class IProneNetbook : INetbook
    {
        public void ShowInfo() => Console.WriteLine("IProne Netbook: компактний і продуктивний!");
    }

    class IProneEBook : IEBook
    {
        public void ShowInfo() => Console.WriteLine("IProne EBook: ідеальний для читання!");
    }

    class IProneSmartphone : ISmartphone
    {
        public void ShowInfo() => Console.WriteLine("IProne Smartphone: передова технологія!");
    }

    class KiaomiLaptop : ILaptop
    {
        public void ShowInfo() => Console.WriteLine("Kiaomi Laptop: надійний та доступний!");
    }

    class KiaomiNetbook : INetbook
    {
        public void ShowInfo() => Console.WriteLine("Kiaomi Netbook: легкий та витривалий!");
    }

    class KiaomiEBook : IEBook
    {
        public void ShowInfo() => Console.WriteLine("Kiaomi EBook: великий екран для читання!");
    }

    class KiaomiSmartphone : ISmartphone
    {
        public void ShowInfo() => Console.WriteLine("Kiaomi Smartphone: якісна камера та батарея!");
    }

    class BalaxyLaptop : ILaptop
    {
        public void ShowInfo() => Console.WriteLine("Balaxy Laptop: сучасний дизайн і потужність!");
    }

    class BalaxyNetbook : INetbook
    {
        public void ShowInfo() => Console.WriteLine("Balaxy Netbook: зручний для подорожей!");
    }

    class BalaxyEBook : IEBook
    {
        public void ShowInfo() => Console.WriteLine("Balaxy EBook: підтримка різних форматів книг!");
    }

    class BalaxySmartphone : ISmartphone
    {
        public void ShowInfo() => Console.WriteLine("Balaxy Smartphone: екран з високою роздільною здатністю!");
    }
    interface ITechFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }
    class IProneFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
    }

    class KiaomiFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    class BalaxyFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("---Виробництво техніки IProne---");
            ITechFactory iproneFactory = new IProneFactory();
            iproneFactory.CreateLaptop().ShowInfo();
            iproneFactory.CreateNetbook().ShowInfo();
            iproneFactory.CreateEBook().ShowInfo();
            iproneFactory.CreateSmartphone().ShowInfo();

            Console.WriteLine("\n---Виробництво техніки Kiaomi---");
            ITechFactory kiaomiFactory = new KiaomiFactory();
            kiaomiFactory.CreateLaptop().ShowInfo();
            kiaomiFactory.CreateNetbook().ShowInfo();
            kiaomiFactory.CreateEBook().ShowInfo();
            kiaomiFactory.CreateSmartphone().ShowInfo();

            Console.WriteLine("\n---Виробництво техніки Balaxy---");
            ITechFactory balaxyFactory = new BalaxyFactory();
            balaxyFactory.CreateLaptop().ShowInfo();
            balaxyFactory.CreateNetbook().ShowInfo();
            balaxyFactory.CreateEBook().ShowInfo();
            balaxyFactory.CreateSmartphone().ShowInfo();

            Console.ReadKey();
        }
    }

}
