using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        HeroBuilder heroBuilder = new HeroBuilder();
        EnemyBuilder enemyBuilder = new EnemyBuilder();
        CharacterDirector director = new CharacterDirector();

        Console.WriteLine("Building a Hero");
        Character hero = BuildCharacter(heroBuilder);

        Console.WriteLine("\nBuilding an Enemy");
        Character enemy = BuildCharacter(enemyBuilder);

        Console.WriteLine("\nHero:");
        hero.DisplayInfo();

        Console.WriteLine("\nEnemy:");
        enemy.DisplayInfo();
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static Character BuildCharacter(ICharacterBuilder builder)
    {
        Console.WriteLine("Enter Height:");
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Physique:");
        string physique = Console.ReadLine();

        Console.WriteLine("Enter Hair Color:");
        string hairColor = Console.ReadLine();

        Console.WriteLine("Enter Eye Color:");
        string eyeColor = Console.ReadLine();

        Console.WriteLine("Enter Clothing:");
        string clothing = Console.ReadLine();

        Console.WriteLine("Enter Inventory (comma-separated list):");
        List<string> inventory = new List<string>(Console.ReadLine().Split(','));

        Console.WriteLine("Enter the number of Good Deeds:");
        int goodDeedsCount = int.Parse(Console.ReadLine());
        List<string> goodDeeds = new List<string>();
        for (int i = 0; i < goodDeedsCount; i++)
        {
            Console.WriteLine($"Enter Good Deed #{i + 1}:");
            goodDeeds.Add(Console.ReadLine());
        }

        Console.WriteLine("Enter the number of Evil Deeds:");
        int evilDeedsCount = int.Parse(Console.ReadLine());
        List<string> evilDeeds = new List<string>();
        for (int i = 0; i < evilDeedsCount; i++)
        {
            Console.WriteLine($"Enter Evil Deed #{i + 1}:");
            evilDeeds.Add(Console.ReadLine());
        }

        if (builder is HeroBuilder)
        {
            HeroBuilder heroBuilder = (HeroBuilder)builder;
            foreach (string deed in goodDeeds)
            {
                heroBuilder.AddGoodDeed(deed);
            }
        }
        else if (builder is EnemyBuilder)
        {
            EnemyBuilder enemyBuilder = (EnemyBuilder)builder;
            foreach (string deed in evilDeeds)
            {
                enemyBuilder.AddEvilDeed(deed);
            }
        }

        return builder
            .SetHeight(height)
            .SetPhysique(physique)
            .SetHairColor(hairColor)
            .SetEyeColor(eyeColor)
            .SetClothing(clothing)
            .SetInventory(inventory)
            .Build();
    }
}