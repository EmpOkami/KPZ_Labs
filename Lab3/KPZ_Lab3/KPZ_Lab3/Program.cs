public class Program
{
    public static void Main(string[] args)
    {
        Logger consoleLogger = new Logger();
        FileWriter fileWriter = new FileWriter("log.txt");

        FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);

        consoleLogger.Log("This is a log message");
        consoleLogger.Error("This is an error message");
        consoleLogger.Warn("This is a warning message");

        fileLogger.Log("This is a log message");
        fileLogger.Error("This is an error message");
        fileLogger.Warn("This is a warning message");
    }
}
