using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    abstract class Subscription
    {
        public abstract string Name { get; }
        public abstract decimal MonthlyFee { get; }
        public abstract int MinPeriod { get; }
        public abstract List<string> Channels { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"Підписка: {Name}");
            Console.WriteLine($"Щомісячна плата: {MonthlyFee} грн");
            Console.WriteLine($"Мінімальний період: {MinPeriod} місяців");
            Console.WriteLine("Канали:");
            Channels.ForEach(channel => Console.WriteLine($" - {channel}"));
            Console.WriteLine();
        }
    }
    class DomesticSubscription : Subscription
    {
        public override string Name => "Домашня";
        public override decimal MonthlyFee => 99.99m;
        public override int MinPeriod => 6;
        public override List<string> Channels => new List<string> { "Новини", "Фільми", "Спорт" };
    }
    class EducationalSubscription : Subscription
    {
        public override string Name => "Освітня";
        public override decimal MonthlyFee => 49.99m;
        public override int MinPeriod => 3;
        public override List<string> Channels => new List<string> { "Наука", "Документальні", "Історія" };
    }
    class PremiumSubscription : Subscription
    {
        public override string Name => "Преміум";
        public override decimal MonthlyFee => 199.99m;
        public override int MinPeriod => 12;
        public override List<string> Channels => new List<string> { "HD Фільми", "Спорт HD", "Ексклюзивні шоу" };
    }
    abstract class SubscriptionFactory
    {
        public abstract Subscription CreateSubscription();
    }

    class WebSiteFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new DomesticSubscription();
    }

    class MobileAppFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new EducationalSubscription();
    }

    class ManagerCallFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription() => new PremiumSubscription();
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SubscriptionFactory webFactory = new WebSiteFactory();
            SubscriptionFactory appFactory = new MobileAppFactory();
            SubscriptionFactory callFactory = new ManagerCallFactory();

            Subscription webSubscription = webFactory.CreateSubscription();
            Subscription appSubscription = appFactory.CreateSubscription();
            Subscription callSubscription = callFactory.CreateSubscription();

            webSubscription.ShowInfo();
            appSubscription.ShowInfo();
            callSubscription.ShowInfo();
            Console.ReadKey();
        }
    }

}
