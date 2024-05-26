using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a method to create a subscription:");
        Console.WriteLine("1. WebSite");
        Console.WriteLine("2. MobileApp");
        Console.WriteLine("3. ManagerCall");

        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose a subscription type:");
        Console.WriteLine("1. Domestic");
        Console.WriteLine("2. Educational");
        Console.WriteLine("3. Premium");

        int subTypeChoice = int.Parse(Console.ReadLine());

        string subscriptionType = subTypeChoice switch
        {
            1 => "Domestic",
            2 => "Educational",
            3 => "Premium",
            _ => throw new ArgumentException("Invalid subscription type")
        };

        SubscriptionFactory factory = choice switch
        {
            1 => new WebSite(subscriptionType),
            2 => new MobileApp(subscriptionType),
            3 => new ManagerCall(subscriptionType),
            _ => throw new ArgumentException("Invalid choice")
        };

        Subscription subscription = factory.CreateSubscription();
        Console.WriteLine($"Subscription Created: {subscription.Name}");
        Console.WriteLine($"Monthly Fee: {subscription.MonthlyFee}");
        Console.WriteLine($"Minimum Period: {subscription.MinimumPeriod} months");
        Console.WriteLine("Channels: " + string.Join(", ", subscription.Channels));
        Console.WriteLine("Features: " + string.Join(", ", subscription.Features));
    }
}
