using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    abstract class Hero
    {
        public abstract void Display();
    }

    class Warrior : Hero
    {
        public override void Display()
        {
            Console.WriteLine("Я воїн, сильний та відважний!");
        }
    }

    class Mage : Hero
    {
        public override void Display()
        {
            Console.WriteLine("Я маг, володар стихій!");
        }
    }

    class Paladin : Hero
    {
        public override void Display()
        {
            Console.WriteLine("Я паладин, захисник світла!");
        }
    }

    abstract class HeroDecorator : Hero
    {
        protected Hero hero;

        public HeroDecorator(Hero hero)
        {
            this.hero = hero;
        }

        public override void Display()
        {
            hero.Display();
        }
    }

    class Armor : HeroDecorator
    {
        public Armor(Hero hero) : base(hero) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("+ Надягнув броню (захист збільшено)");
        }
    }

    class Sword : HeroDecorator
    {
        public Sword(Hero hero) : base(hero) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("+ Озброївся мечем (атака збільшена)");
        }
    }

    class Amulet : HeroDecorator
    {
        public Amulet(Hero hero) : base(hero) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("+ Надягнув амулет (магічні здібності посилено)");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Hero warrior = new Warrior();
            warrior = new Armor(warrior);
            warrior = new Sword(warrior);
            warrior.Display();

            Console.WriteLine();

            Hero mage = new Mage();
            mage = new Amulet(mage);
            mage = new Armor(mage);
            mage.Display();

            Console.WriteLine();

            Hero paladin = new Paladin();
            paladin = new Sword(paladin);
            paladin = new Armor(paladin);
            paladin = new Amulet(paladin);
            paladin.Display();
            Console.ReadKey();
        }
    }
}
