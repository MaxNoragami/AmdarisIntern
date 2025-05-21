namespace Task11FileSystemStreams.Entities;

public abstract class Entity(int id) : ICloneable
{
    public int Id { get; private set; } = id;

    public virtual object Clone() => MemberwiseClone();
}

