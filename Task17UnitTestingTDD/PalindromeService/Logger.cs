using System.Diagnostics;

namespace PalindromeService;

public interface ILogger
{
    public void Log(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        using (var logWriter = File.AppendText($"Logs/{DateTime.Now:yyyy-MMM-dd}.txt"))
        {
            logWriter.WriteLine(message);
            logWriter.WriteLine();
            logWriter.Flush();
        }
    }
}

public class SafeLogger(ILogger logger) : ILogger
{
    private readonly ILogger _logger = logger;
    public void Log(string message)
    {
        try
        {
            _logger.Log(message);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"FAILURE: {ex.Message}");
        }
    }
}
