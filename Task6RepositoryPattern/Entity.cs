namespace Task6RepositoryPattern;

internal abstract class Entity(int id)
{
    public int Id { get; private set; } = id;
}

