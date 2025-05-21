namespace BusinessLayer.Exceptions;

public class NoSessionsApprovedException : Exception
{
    public NoSessionsApprovedException()
        : base() { }

    public NoSessionsApprovedException(string message)
        : base(message) { }
}
