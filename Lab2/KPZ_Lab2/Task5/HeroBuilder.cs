using System.Collections.Generic;

public class HeroBuilder : ICharacterBuilder
{
    private Character _character;

    public HeroBuilder()
    {
        _character = new Character
        {
            GoodDeeds = new List<string>()
        };
    }

    public ICharacterBuilder SetHeight(double height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetPhysique(string physique)
    {
        _character.Physique = physique;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        _character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        _character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder SetInventory(List<string> inventory)
    {
        _character.Inventory = inventory;
        return this;
    }

    public HeroBuilder AddGoodDeed(string goodDeed)
    {
        _character.GoodDeeds.Add(goodDeed);
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}