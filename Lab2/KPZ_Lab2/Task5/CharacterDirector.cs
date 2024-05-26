public class CharacterDirector
{
    public Character ConstructHero(HeroBuilder builder)
    {
        return builder
            .SetHeight(180)
            .SetPhysique("Athletic")
            .SetHairColor("Blonde")
            .SetEyeColor("Blue")
            .SetClothing("Armor")
            .SetInventory(new List<string> { "Sword", "Shield" })
            .Build();
    }

    public Character ConstructEnemy(EnemyBuilder builder)
    {
        return builder
            .SetHeight(190)
            .SetPhysique("Muscular")
            .SetHairColor("Black")
            .SetEyeColor("Red")
            .SetClothing("Dark Robe")
            .SetInventory(new List<string> { "Dark Staff", "Poison" })
            .Build();
    }
}