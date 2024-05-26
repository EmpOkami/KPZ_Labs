using System;
using System.Collections.Generic;

public class Virus
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(double weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    public Virus Clone()
    {
        Virus clone = new Virus(Weight, Age, Name, Type);
        foreach (var child in Children)
        {
            clone.Children.Add(child.Clone());
        }
        return clone;
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public void PrintInfo(string indent = "")
    {
        Console.WriteLine($"{indent}Virus: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}");
        foreach (var child in Children)
        {
            child.PrintInfo(indent + "  ");
        }
    }
}
