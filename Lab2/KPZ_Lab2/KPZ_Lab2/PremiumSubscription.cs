using System.Collections.Generic;

public class PremiumSubscription : Subscription
{
    public override string Name => "Premium Subscription";
    public override decimal MonthlyFee => 19.99m;
    public override int MinimumPeriod => 1; // місяць
    public override List<string> Channels => new List<string> { "All Channels" };
    public override List<string> Features => new List<string> { "4K Quality", "No Ads", "Exclusive Content" };
}
