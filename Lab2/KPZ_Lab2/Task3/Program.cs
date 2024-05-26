using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Однопотокова демонстрація
        var auth1 = Authenticator.Instance;
        var auth2 = Authenticator.Instance;

        Console.WriteLine($"auth1 == auth2: {auth1 == auth2}");

        auth1.Authenticate("User1");

        // Багатопотокова демонстрація
        Parallel.Invoke(
            () =>
            {
                var auth3 = Authenticator.Instance;
                Console.WriteLine($"auth3: {auth3.GetHashCode()}");
                auth3.Authenticate("User2");
            },
            () =>
            {
                var auth4 = Authenticator.Instance;
                Console.WriteLine($"auth4: {auth4.GetHashCode()}");
                auth4.Authenticate("User3");
            }
        );

        // Очікування завершення виконання
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
