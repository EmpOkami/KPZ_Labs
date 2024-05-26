using System;
using System.Text.RegularExpressions;

public class SmartTextReaderLocker : IReader
{
    private SmartTextReader _reader;
    private Regex _regex;

    public SmartTextReaderLocker(SmartTextReader reader, string pattern)
    {
        _reader = reader;
        _regex = new Regex(pattern);
    }

    public char[][] ReadFile(string filePath)
    {
        if (_regex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null;
        }
        return _reader.ReadFile(filePath);
    }
}
