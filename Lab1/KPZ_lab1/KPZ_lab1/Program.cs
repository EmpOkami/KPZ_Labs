using System;

class Program
{
    static void Main()
    {
        Warehouse warehouse = new Warehouse();
        Reporting reporting = new Reporting();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Display inventory");
            Console.WriteLine("4. Reduce product price");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(warehouse, reporting);
                    break;
                case "2":
                    RemoveProduct(warehouse, reporting);
                    break;
                case "3":
                    reporting.InventoryReport(warehouse);
                    break;
                case "4":
                    ReduceProductPrice(warehouse);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct(Warehouse warehouse, Reporting reporting)
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter whole part of the price: ");
        int wholePart = int.Parse(Console.ReadLine());

        Console.Write("Enter cents part of the price: ");
        int centsPart = int.Parse(Console.ReadLine());

        Money price = new Money(wholePart, centsPart);
        Product product = new Product(name, price);

        reporting.GenerateReceivingReport(warehouse, product);
    }

    static void RemoveProduct(Warehouse warehouse, Reporting reporting)
    {
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine();

        reporting.GenerateShippingReport(warehouse, name);
    }

    static void ReduceProductPrice(Warehouse warehouse)
    {
        Console.Write("Enter product name to reduce price: ");
        string name = Console.ReadLine();

        Product product = warehouse.Products.Find(p => p.Name == name);
        if (product != null)
        {
            Console.Write("Enter amount to reduce price by (in cents): ");
            int amount = int.Parse(Console.ReadLine());

            product.ReducePrice(amount);
            Console.WriteLine($"New price for {product.Name} is {product.Price.WholePart}.{product.Price.CentsPart:D2}");
        }
        else
        {
            Console.WriteLine($"Product {name} not found.");
        }
    }
}