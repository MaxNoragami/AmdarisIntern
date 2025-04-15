namespace Task7Exceptions;

public class ExceptionLogger : IDisposable
{
    private bool _disposed = false;
    private StreamWriter? _logWriter;
    private readonly string _logFilePath;

    public ExceptionLogger(string logFilePath)
    {
        _logFilePath = (File.Exists(logFilePath)) ? 
                logFilePath : 
                throw new ArgumentException("File path is not existent");

        _logWriter = new StreamWriter(File.Open(_logFilePath,
                                                FileMode.Append,
                                                FileAccess.Write,
                                                FileShare.Read));
    }
    
    public void LogException(Exception ex)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(ExceptionLogger));

        var momentInTime = DateTime.Now.ToString("yy-MM-dd HH:mm:ss");

        _logWriter?.WriteLine($"[{momentInTime}] - Exception: {ex.GetType().Name}");
        _logWriter?.WriteLine($"Message: {ex.Message}");
        _logWriter?.WriteLine($"Stack Trace: {ex.StackTrace}");

        _logWriter?.WriteLine(new string('*', 60));
        _logWriter?.Flush();

    }

    public void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if(disposing)
        {
            _logWriter?.Flush();
            _logWriter?.Dispose();
            _logWriter = null;
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ExceptionLogger()
    {
        Dispose(false);
    }
}
