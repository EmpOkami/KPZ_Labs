### README.md

# Principles Demonstrated

## SOLID Principles

1. **Single Responsibility Principle (SRP)**:
   - Each class has one responsibility. The `Money` class handles money operations, the `Product` class manages products, the `Warehouse` class manages the warehouse, and the `Reporting` class handles reporting.
     ```csharp
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

2. **Open/Closed Principle (OCP)**:
   - Classes are open for extension but closed for modification. The `Product` class can be extended with new properties or methods without changing the existing code.
    ```csharp
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
    
3. **Liskov Substitution Principle (LSP)**:
   - The LSP principle can be applied if inheritance is used. For example, subclasses of Product could replace the base class without breaking the functionality of the program.
     
4. **Interface Segregation Principle (ISP)**:
   - ISP is implicitly demonstrated by not overloading classes with unnecessary methods and ensuring each method performs a single functionality.

5. **Dependency Inversion Principle (DIP)**:
   - The DIP principle can be implemented using interfaces to define abstractions. For instance, interfaces could be created for Warehouse and Reporting.

  
  ## Other Principles
1.  **DRY (Don't Repeat Yourself)**:
   - Code repetition is avoided by extracting common functionalities into separate methods.
     ```csharp
      public void DisplayInventory()
      {
          Console.WriteLine("Warehouse Inventory:");
          foreach (var product in Products)
          {
              product.DisplayProduct();
          }
          Console.WriteLine($"Last Delivery Date: {LastDeliveryDate}");
      }
     
2. **KISS (Keep It Simple, Stupid)**:
   - The code maintains simplicity and clarity, with each class focusing on well-defined tasks.
     ```csharp
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
      }
     
3. **YAGNI (You Aren't Gonna Need It)**:
   - Only necessary functionalities are implemented, avoiding unnecessary features.
     ```csharp
           public void ReducePrice(int amount)
      {
          int totalCents = Price.WholePart * 100 + Price.CentsPart - amount;
          if (totalCents < 0) totalCents = 0;
          Price.SetMoney(totalCents / 100, totalCents % 100);
      }
     
4. **Composition Over Inheritance**:
   - Composition is favored over inheritance, promoting better code organization and flexibility.
     ```csharp
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

5. **Program to Interfaces, not Implementations**:
6. **Fail Fast**:
   - The Fail Fast principle is followed by promptly checking the validity of values after changes. For example, when reducing the price of a product, the system ensures the total price is not negative.
     ```csharp
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
      
              // Fail Fast: Ensure total price is not negative
              if (totalCents < 0)
              {
                  throw new InvalidOperationException("Price cannot be negative.");
              }
      
              Price.SetMoney(totalCents / 100, totalCents % 100);
          }
      
          public void DisplayProduct()
          {
              Console.WriteLine($"Product: {Name}, Price: {Price.WholePart}.{Price.CentsPart:D2}");
          }
      }
[Money.cs](Money.cs)
[Product.cs](Product.cs)
[Program.cs](Program.cs)
[Reporting.cs](Reporting.cs)
[Warehouse.cs](Warehouse.cs)
