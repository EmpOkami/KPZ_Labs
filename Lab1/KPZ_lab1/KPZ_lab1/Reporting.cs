using System;

public class Reporting
{
    public void GenerateReceivingReport(Warehouse warehouse, Product product)
    {
        warehouse.AddProduct(product);
        Console.WriteLine($"Receiving Report: Added {product.Name} at {DateTime.Now}");
    }

    public void GenerateShippingReport(Warehouse warehouse, string productName)
    {
        warehouse.RemoveProduct(productName);
        Console.WriteLine($"Shipping Report: Removed {productName} at {DateTime.Now}");
    }

    public void InventoryReport(Warehouse warehouse)
    {
        warehouse.DisplayInventory();
    }
}