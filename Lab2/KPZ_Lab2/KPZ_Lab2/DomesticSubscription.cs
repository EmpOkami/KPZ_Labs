using System.Collections.Generic;

public class DomesticSubscription : Subscription
{
    public override string Name => "Domestic Subscription";
    public override decimal MonthlyFee => 10.99m;
    public override int MinimumPeriod => 6; // місяців
    public override List<string> Channels => new List<string> { "News", "Sports", "Movies" };
    public override List<string> Features => new List<string> { "HD Quality", "On-demand" };
}
