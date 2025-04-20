namespace Task11FileSystemStreams.ExceptionClasses;

public class DataValidationException<T> : Exception
{
    public DataValidationException() : base("The set data is not valid") { }
    public DataValidationException(string message) : base(message) { }
    public DataValidationException(params T[] data) :
        base(
            $"""The set data: {string.Join(", ", data)}, is invalid."""
        )
    { }
}
