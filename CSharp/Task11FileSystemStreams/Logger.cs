namespace Task11FileSystemStreams;

public static class Logger
{
    
    public static void Log(object? sender, BusinessOperationEventArgs eventArgs)
    {
        // Fire and Forget
        _ = LogAsync(eventArgs);
    }

    private static async Task LogAsync(BusinessOperationEventArgs eventArgs)
    {
        var momentInTime = DateTime.Now;
        var dateOnly = DateOnly.FromDateTime(momentInTime);

        using (var logWriter = File.AppendText($"Logs/{dateOnly:yyyy-MMM-dd}.txt"))
        {
            await logWriter.WriteLineAsync($"[{momentInTime}] - {eventArgs.MethodName}() - " +
                $"{(eventArgs.Success? "SUCCESS" : "FAILURE\nException: " + eventArgs.Ex?.GetType().Name)}");

            if (eventArgs.Ex != null)
            {
                await logWriter.WriteLineAsync($"Exception Message:\n\t{eventArgs.Ex.Message}");
                await logWriter.WriteLineAsync($"Stack Trace:\n\t{eventArgs.Ex.StackTrace}");
            }

            if (!string.IsNullOrWhiteSpace(eventArgs.Message))
                await logWriter.WriteLineAsync($"Message:\n\t{eventArgs.Message}");

            if (eventArgs.Parameters != null)
                await logWriter.WriteLineAsync($"Parameters:\n\t{string.Join("\n\t", eventArgs.Parameters.Keys.Zip(eventArgs.Parameters.Values, (k, v) => k + " = " + v))}");

            await logWriter.WriteLineAsync();
            await logWriter.WriteLineAsync(new string('-', 80));
            await logWriter.WriteLineAsync();
            await logWriter.FlushAsync();
        }
    }

    public static async Task ViewLogAsync()
    {
        var momentInTime = DateTime.Now;
        var dateOnly = DateOnly.FromDateTime(momentInTime);

        using (var logReader = new StreamReader($"Logs/{dateOnly:yyyy-MMM-dd}.txt"))
        {
            Console.WriteLine("********** Daily Log **********\n");
            for(var line = await logReader.ReadLineAsync(); line != null; line = await logReader.ReadLineAsync())
                Console.WriteLine(line);
        }
    }
}
