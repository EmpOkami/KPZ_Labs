using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> deviceCount = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        IDeviceFactory factory = null;

        while (true)
        {
            Console.WriteLine("Choose a brand to create devices:");
            Console.WriteLine("1. IProne");
            Console.WriteLine("2. Kiaomi");
            Console.WriteLine("3. Balaxy");
            Console.WriteLine("4. View created devices");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 5) break;

            switch (choice)
            {
                case 1:
                    factory = new IProneFactory();
                    break;
                case 2:
                    factory = new KiaomiFactory();
                    break;
                case 3:
                    factory = new BalaxyFactory();
                    break;
                case 4:
                    ViewCreatedDevices();
                    continue;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
            }

            ShowCurrentDevices(factory);
            CreateDevice(factory);
        }
    }

    static void CreateDevice(IDeviceFactory factory)
    {
        Console.WriteLine("Choose a device to create:");
        Console.WriteLine("1. Laptop");
        Console.WriteLine("2. Netbook");
        Console.WriteLine("3. EBook");
        Console.WriteLine("4. Smartphone");

        int deviceChoice = int.Parse(Console.ReadLine());
        IDevice device = null;
        string deviceName = string.Empty;

        switch (deviceChoice)
        {
            case 1:
                device = factory.CreateLaptop();
                deviceName = $"{device.GetName()}";
                break;
            case 2:
                device = factory.CreateNetbook();
                deviceName = $"{device.GetName()}";
                break;
            case 3:
                device = factory.CreateEBook();
                deviceName = $"{device.GetName()}";
                break;
            case 4:
                device = factory.CreateSmartphone();
                deviceName = $"{device.GetName()}";
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                return;
        }

        if (deviceCount.ContainsKey(deviceName))
        {
            deviceCount[deviceName]++;
        }
        else
        {
            deviceCount[deviceName] = 1;
        }

        Console.WriteLine($"Created device: {deviceName}");
    }

    static void ShowCurrentDevices(IDeviceFactory factory)
    {
        Console.WriteLine("Current devices:");
        foreach (var entry in deviceCount)
        {
            if (entry.Key.StartsWith(factory.GetType().Name.Replace("Factory", "")))
            {
                Console.WriteLine($"{entry.Key} {entry.Value}");
            }
        }
    }

    static void ViewCreatedDevices()
    {
        Console.WriteLine("Created devices:");
        foreach (var entry in deviceCount)
        {
            Console.WriteLine($"{entry.Key} {entry.Value}");
        }
    }
}
