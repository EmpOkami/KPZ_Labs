using System;

public class Program
{
    public static void Main(string[] args)
    {
        IHero warrior = new Warrior();
        IHero mage = new Mage();
        IHero palladin = new Palladin();

        Console.WriteLine("Initial heroes:");
        DisplayHero(warrior);
        DisplayHero(mage);
        DisplayHero(palladin);

        while (true)
        {
            Console.WriteLine("Choose a hero to equip (1 - Warrior, 2 - Mage, 3 - Palladin, 0 - Exit):");
            int heroChoice = int.Parse(Console.ReadLine());

            if (heroChoice == 0) break;

            IHero chosenHero = heroChoice switch
            {
                1 => warrior,
                2 => mage,
                3 => palladin,
                _ => null
            };

            if (chosenHero == null)
            {
                Console.WriteLine("Invalid choice, please try again.");
                continue;
            }

            Console.WriteLine("Choose an item to add (1 - Armor (+20), 2 - Weapon (+30), 3 - Artifact (+15)):");
            int itemChoice = int.Parse(Console.ReadLine());

            chosenHero = itemChoice switch
            {
                1 => new Armor(chosenHero),
                2 => new Weapon(chosenHero),
                3 => new Artifact(chosenHero),
                _ => chosenHero
            };

            switch (heroChoice)
            {
                case 1:
                    warrior = chosenHero;
                    break;
                case 2:
                    mage = chosenHero;
                    break;
                case 3:
                    palladin = chosenHero;
                    break;
            }

            Console.WriteLine("Updated heroes:");
            DisplayHero(warrior);
            DisplayHero(mage);
            DisplayHero(palladin);
        }
    }

    private static void DisplayHero(IHero hero)
    {
        Console.WriteLine($"{hero.GetDescription()} has power {hero.GetPower()}");
    }
}
