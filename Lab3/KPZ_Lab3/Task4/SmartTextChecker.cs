using System;

public class SmartTextChecker : IReader
{
    private SmartTextReader _reader;

    public SmartTextChecker(SmartTextReader reader)
    {
        _reader = reader;
    }

    public char[][] ReadFile(string filePath)
    {
        Console.WriteLine("Attempting to open file: " + filePath);

        char[][] content = _reader.ReadFile(filePath);

        Console.WriteLine("File successfully opened and read.");
        Console.WriteLine("File closed.");

        int lineCount = content.Length;
        int charCount = 0;
        foreach (var line in content)
        {
            charCount += line.Length;
        }

        Console.WriteLine($"Total lines: {lineCount}");
        Console.WriteLine($"Total characters: {charCount}");

        return content;
    }
}
