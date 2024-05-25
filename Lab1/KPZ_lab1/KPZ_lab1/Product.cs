using System;

public class Product
{
    public string Name { get; private set; }
    public Money Price { get; private set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void ReducePrice(int amount)
    {
        int totalCents = Price.WholePart * 100 + Price.CentsPart - amount;
        if (totalCents < 0) totalCents = 0;
        Price.SetMoney(totalCents / 100, totalCents % 100);
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price.WholePart}.{Price.CentsPart:D2}");
    }
}