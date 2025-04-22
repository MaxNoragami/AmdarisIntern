using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Task11FileSystemStreams;

public class BusinessOperationEventArgs: EventArgs
{
    public required string MethodName { get; init; }
    public required bool Success { get; init; }
    public string Message { get; init; }
    public Dictionary<string, object>? Parameters { get; init; }
    public Exception? Ex { get; init; }

    [SetsRequiredMembers]
    public BusinessOperationEventArgs( string methodName, 
                                      bool success, 
                                      [Optional] string message, 
                                      [Optional] Dictionary<string, object>? parameters, 
                                      [Optional] Exception? exception)
    {
        MethodName = methodName;
        Success = success;
        Message = message;
        Parameters = parameters;
        Ex = exception;
    }
}
