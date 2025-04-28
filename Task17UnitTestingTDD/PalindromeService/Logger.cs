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
