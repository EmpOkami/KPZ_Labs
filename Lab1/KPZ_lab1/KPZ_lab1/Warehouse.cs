using System;
using System.Collections.Generic;

public class Warehouse
{
    public List<Product> Products { get; private set; }
    public DateTime LastDeliveryDate { get; private set; }

    public Warehouse()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        LastDeliveryDate = DateTime.Now;
    }

    public void RemoveProduct(string productName)
    {
        Product productToRemove = Products.Find(p => p.Name == productName);
        if (productToRemove != null)
        {
            Products.Remove(productToRemove);
            Console.WriteLine($"Product {productName} removed.");
        }
        else
        {
            Console.WriteLine($"Product {productName} not found.");
        }
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Warehouse Inventory:");
        foreach (var product in Products)
        {
            product.DisplayProduct();
        }
        Console.WriteLine($"Last Delivery Date: {LastDeliveryDate}");
    }
}