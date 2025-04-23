using System;

namespace BusinessLayer.CustomExceptions
{
    public class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException(string message)
            : base(message) 
        { 
        }
    }
}
