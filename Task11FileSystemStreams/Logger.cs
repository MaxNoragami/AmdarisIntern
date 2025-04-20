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
            logWriter.WriteLine($"[{momentInTime}] - {eventArgs.MethodName}() - " +
                $"{(eventArgs.Success? "SUCCESS" : "FAILURE\nException: " + eventArgs.Ex?.GetType().Name)}");

            if (eventArgs.Ex != null)
            {
                logWriter.WriteLine($"Exception Message:\n\t{eventArgs.Ex.Message}");
                logWriter.WriteLine($"Stack Trace:\n\t{eventArgs.Ex.StackTrace}");
            }

            if (!string.IsNullOrWhiteSpace(eventArgs.Message))
                logWriter.WriteLine($"Message:\n\t{eventArgs.Message}");

            if (eventArgs.Parameters != null)
                logWriter.WriteLine($"Parameters:\n\t{string.Join("\n\t", eventArgs.Parameters.Keys.Zip(eventArgs.Parameters.Values, (k, v) => k + " = " + v))}");

            logWriter.WriteLine();
            logWriter.WriteLine(new string('-', 80));
            logWriter.WriteLine();
            logWriter.Flush();
        }
    }


}
