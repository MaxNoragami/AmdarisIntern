namespace Task11FileSystemStreams;

public class BusinessOperationEventArgs(string methodName, 
                                        bool success, 
                                        string message = "", 
                                        Dictionary<string, object>? parameters = null, 
                                        Exception? exception = null) 
                                    : EventArgs
{
    public string MethodName => methodName;
    public bool Success => success;
    public string Message => message;
    public Dictionary<string, object>? Parameters => parameters;
    public Exception? Ex => exception;
}
