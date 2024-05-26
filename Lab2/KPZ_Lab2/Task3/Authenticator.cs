using System;

public sealed class Authenticator
{
    private static Authenticator _instance;
    private static readonly object _lock = new object();

    // Приватний конструктор для запобігання створенню екземплярів ззовні
    private Authenticator()
    {
        Console.WriteLine("Authenticator instance created");
    }

    // Метод для отримання екземпляра класу
    public static Authenticator Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Authenticator();
                }
                return _instance;
            }
        }
    }

    // Демонстраційний метод
    public void Authenticate(string user)
    {
        Console.WriteLine($"Authenticating user: {user}");
    }
}
