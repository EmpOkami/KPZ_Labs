using System;

class Program
{
    static void Main(string[] args)
    {
        Virus parentVirus = new Virus(1.5, 3, "ParentVirus", "TypeA");
        Virus childVirus1 = new Virus(0.8, 1, "ChildVirus1", "TypeA");
        Virus childVirus2 = new Virus(0.9, 2, "ChildVirus2", "TypeA");
        Virus grandchildVirus = new Virus(0.5, 1, "GrandchildVirus", "TypeA");

        childVirus1.AddChild(grandchildVirus);
        parentVirus.AddChild(childVirus1);
        parentVirus.AddChild(childVirus2);

        Virus clonedVirus = parentVirus.Clone();

        Console.WriteLine("Original Virus Family:");
        parentVirus.PrintInfo();

        Console.WriteLine("\nCloned Virus Family:");
        clonedVirus.PrintInfo();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
