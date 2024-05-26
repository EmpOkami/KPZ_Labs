public class Weapon : HeroDecorator
{
    public Weapon(IHero hero) : base(hero)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Weapon (+30)";
    }

    public override int GetPower()
    {
        return base.GetPower() + 30;
    }
}
