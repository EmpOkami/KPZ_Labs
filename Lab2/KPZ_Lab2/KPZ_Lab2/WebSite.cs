public class WebSite : SubscriptionFactory
{
    private string _subscriptionType;

    public WebSite(string subscriptionType)
    {
        _subscriptionType = subscriptionType;
    }

    public override Subscription CreateSubscription()
    {
        return _subscriptionType switch
        {
            "Domestic" => new DomesticSubscription(),
            "Educational" => new EducationalSubscription(),
            "Premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Invalid subscription type")
        };
    }
}
