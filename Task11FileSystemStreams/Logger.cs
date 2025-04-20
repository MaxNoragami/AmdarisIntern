using System.Reflection.Metadata;
using Task11FileSystemStreams;

namespace Task7Exceptions;

public class Logger
{
    
    public void Log(object? sender, BusinessOperationEventArgs eventArgs)
    {
        var momentInTime = DateTime.Now;
        var dateOnly = DateOnly.FromDateTime(momentInTime);

        using (var logWriter = File.AppendText($"Logs/{dateOnly:yyyy-MMM-dd}.txt"))
        {
            logWriter.WriteLine($"[{momentInTime}] - Exception: {eventArgs.Ex.GetType().Name}");
            logWriter.WriteLine($"Message: {eventArgs.Ex.Message}");
            logWriter.WriteLine($"Stack Trace: {eventArgs.Ex.StackTrace}");

            logWriter.WriteLine(new string('*', 120));
            logWriter.Flush();
        }

        
    }
}
