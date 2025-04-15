namespace Task7Exceptions;

internal class ListRepository<T>(IList<T> items) : IRepository<T> where T : Entity
{
    private readonly IList<T> _items = items;

    public T Add(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _items.Add((T)entity.Clone());
        return entity;
    }

    public void Delete(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var item = _items.FirstOrDefault(e => e.Id == entity.Id) ?? throw new ArgumentException($"No {typeof(T)} of id {entity.Id} has been found.");
        _items.Remove(item);
    }

    public IList<T> FindAll() => _items.Select(item => (T)item.Clone()).ToList();

    public T GetById(int id)
    {
        var item = _items.FirstOrDefault(e => e.Id == id);
        if (item == null) throw new ArgumentException(nameof(id), $"No {typeof(T)} of id {id} has been found.");
        return (T)(item).Clone();
    }

    public void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var item = _items.FirstOrDefault(e => e.Id == entity.Id) ?? throw new ArgumentNullException($"No {typeof(T)} of id {entity.Id} has been found.");

        var index = _items.IndexOf(item);
        if (index == -1) throw new ArgumentException($"No {typeof(T)} of id {entity.Id} has been found.");

        _items[index] = (T)entity.Clone();
    }
}
