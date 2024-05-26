using System.IO;

public class FileWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string message)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.Write(message);
        }
    }

    public void WriteLine(string message)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(message);
        }
    }
}
