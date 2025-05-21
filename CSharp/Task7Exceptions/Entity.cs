namespace Task7Exceptions;

public abstract class Entity(int id) : ICloneable
{
    public int Id { get; private set; } = id;

    public virtual object Clone() => MemberwiseClone();
}

