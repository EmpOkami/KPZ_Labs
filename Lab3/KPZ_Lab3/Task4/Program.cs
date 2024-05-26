using System;

public class Program
{
    public static void Main(string[] args)
    {
        string testFilePath = @"C:\VisualStudio\KPZ\Lab3\KPZ_Lab3\Task4\testfile.txt";
        string restrictedFilePath = @"C:\VisualStudio\KPZ\Lab3\KPZ_Lab3\Task4\restrictedfile.txt";

        SmartTextReader reader = new SmartTextReader();

        SmartTextChecker checker = new SmartTextChecker(reader);

        SmartTextReaderLocker locker = new SmartTextReaderLocker(reader, @"restricted.*\.txt");

        Console.WriteLine("Using SmartTextChecker:");
        char[][] result = checker.ReadFile(testFilePath);
        if (result != null)
        {
            foreach (var line in result)
            {
                Console.WriteLine(new string(line));
            }
        }

        Console.WriteLine("\nUsing SmartTextReaderLocker:");
        locker.ReadFile(testFilePath);

        Console.WriteLine("\nTrying to access restricted file:");
        locker.ReadFile(restrictedFilePath);
    }
}
