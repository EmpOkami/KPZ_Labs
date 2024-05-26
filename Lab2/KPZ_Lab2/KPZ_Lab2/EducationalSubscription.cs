using System.Collections.Generic;

public class EducationalSubscription : Subscription
{
    public override string Name => "Educational Subscription";
    public override decimal MonthlyFee => 5.99m;
    public override int MinimumPeriod => 12; // місяців
    public override List<string> Channels => new List<string> { "Science", "History", "Documentaries" };
    public override List<string> Features => new List<string> { "HD Quality", "Exclusive Content" };
}
