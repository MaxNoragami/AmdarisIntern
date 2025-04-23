namespace Task13CleanCode.Exceptions;

public class NoSessionsApprovedException : Exception
{
    public NoSessionsApprovedException()
        : base() { }

    public NoSessionsApprovedException(string message)
        : base(message) { }
}
