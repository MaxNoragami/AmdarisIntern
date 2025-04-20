using Task11FileSystemStreams.Entities;

namespace Task11FileSystemStreams.ExceptionClasses;

public class DuplicateIdException : Exception
{
    public DuplicateIdException() : base("An entity with the set ID already exists.") { }
    public DuplicateIdException(string message) : base(message) { }
    public DuplicateIdException(Entity entity) :
        base($"Entity with Id {entity.Id} already exists.") { }
}
