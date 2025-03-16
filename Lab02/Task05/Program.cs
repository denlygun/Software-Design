using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class Character
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string BodyType { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Actions { get; set; } = new List<string>();

        public void ShowInfo()
        {
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Зріст: {Height}, Статура: {BodyType}");
            Console.WriteLine($"Колір волосся: {HairColor}, Колір очей: {EyeColor}");
            Console.WriteLine($"Одяг: {Outfit}");
            Console.WriteLine("Інвентар: " + string.Join(", ", Inventory));
            Console.WriteLine("Дії: " + string.Join(", ", Actions));
            Console.WriteLine("------------------------");
        }
    }

    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(string height);
        ICharacterBuilder SetBodyType(string bodyType);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder SetOutfit(string outfit);
        ICharacterBuilder AddToInventory(string item);
        ICharacterBuilder AddAction(string action);
        Character Build();
    }

    public class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetName(string name) { _character.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _character.Height = height; return this; }
        public ICharacterBuilder SetBodyType(string bodyType) { _character.BodyType = bodyType; return this; }
        public ICharacterBuilder SetHairColor(string hairColor) { _character.HairColor = hairColor; return this; }
        public ICharacterBuilder SetEyeColor(string eyeColor) { _character.EyeColor = eyeColor; return this; }
        public ICharacterBuilder SetOutfit(string outfit) { _character.Outfit = outfit; return this; }
        public ICharacterBuilder AddToInventory(string item) { _character.Inventory.Add(item); return this; }
        public ICharacterBuilder AddAction(string action) { _character.Actions.Add(action); return this; }
        public Character Build() { return _character; }
    }

    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetName(string name) { _character.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _character.Height = height; return this; }
        public ICharacterBuilder SetBodyType(string bodyType) { _character.BodyType = bodyType; return this; }
        public ICharacterBuilder SetHairColor(string hairColor) { _character.HairColor = hairColor; return this; }
        public ICharacterBuilder SetEyeColor(string eyeColor) { _character.EyeColor = eyeColor; return this; }
        public ICharacterBuilder SetOutfit(string outfit) { _character.Outfit = outfit; return this; }
        public ICharacterBuilder AddToInventory(string item) { _character.Inventory.Add(item); return this; }
        public ICharacterBuilder AddAction(string action) { _character.Actions.Add(action); return this; }
        public Character Build() { return _character; }
    }

    public class CharacterDirector
    {
        public Character CreateHero(ICharacterBuilder builder)
        {
            return builder.SetName("Артур")
                          .SetHeight("Високий")
                          .SetBodyType("Мускулистий")
                          .SetHairColor("Блондин")
                          .SetEyeColor("Блакитні")
                          .SetOutfit("Лицарські обладунки")
                          .AddToInventory("Меч")
                          .AddToInventory("Щит")
                          .AddAction("Врятував село")
                          .Build();
        }

        public Character CreateEnemy(ICharacterBuilder builder)
        {
            return builder.SetName("Темний Лорд")
                          .SetHeight("Високий")
                          .SetBodyType("Стрункий, але сильний")
                          .SetHairColor("Чорний")
                          .SetEyeColor("Червоні")
                          .SetOutfit("Темний плащ")
                          .AddToInventory("Чарівний посох")
                          .AddAction("Зруйнував королівство")
                          .Build();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            CharacterDirector director = new CharacterDirector();

            Character hero = director.CreateHero(new HeroBuilder());
            Character enemy = director.CreateEnemy(new EnemyBuilder());

            hero.ShowInfo();
            enemy.ShowInfo();

            Console.ReadKey();
        }
    }

}
