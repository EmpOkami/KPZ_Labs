using System;
using System.Collections.Generic;

public class Character
{
    public double Height { get; set; }
    public string Physique { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; }
    public List<string> GoodDeeds { get; set; }
    public List<string> EvilDeeds { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Physique: {Physique}");
        Console.WriteLine($"HairColor: {HairColor}");
        Console.WriteLine($"EyeColor: {EyeColor}");
        Console.WriteLine($"Clothing: {Clothing}");
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));

        if (GoodDeeds != null)
        {
            Console.WriteLine("Good Deeds: " + string.Join(", ", GoodDeeds));
        }
        if (EvilDeeds != null)
        {
            Console.WriteLine("Evil Deeds: " + string.Join(", ", EvilDeeds));
        }
    }
}