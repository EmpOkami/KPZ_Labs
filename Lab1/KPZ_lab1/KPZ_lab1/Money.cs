using System;

public class Money
{
    public int WholePart { get; private set; }
    public int CentsPart { get; private set; }

    public Money(int wholePart, int centsPart)
    {
        WholePart = wholePart;
        CentsPart = centsPart;
    }

    public void SetMoney(int wholePart, int centsPart)
    {
        WholePart = wholePart;
        CentsPart = centsPart;
    }

    public void DisplayMoney()
    {
        Console.WriteLine($"{WholePart}.{CentsPart:D2}");
    }
}