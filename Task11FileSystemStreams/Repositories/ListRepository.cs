using Task7Exceptions;
using Task7Exceptions.ExceptionClasses;

namespace Task11FileSystemStreams.Repositories;

public class ListRepository<T>(IList<T> items) : IRepository<T> where T : Entity
{
    private readonly IList<T> _items = items;

    public T Add(T entity)
    {
        if (_items.Any(e => e.Id == entity.Id))
            throw new DuplicateIdException(entity);
        _items.Add((T)entity.Clone());
        return entity;
    }

    public void Delete(T entity)
    {
        var item = _items.FirstOrDefault(e => e.Id == entity.Id) ?? throw new ArgumentException($"No {typeof(T)} of id {entity.Id} has been found.");
        _items.Remove(item);
    }

    public IList<T> FindAll() => _items.Select(item => (T)item.Clone()).ToList();

    public T GetById(int id)
    {
        var item = _items.FirstOrDefault(e => e.Id == id);
        if (item == null) throw new ArgumentException(nameof(id), $"No {typeof(T)} of id {id} has been found.");
        return (T)item.Clone();
    }

    public void Update(T entity)
    {
        var item = _items.FirstOrDefault(e => e.Id == entity.Id) ?? throw new ArgumentNullException($"No {typeof(T)} of id {entity.Id} has been found.");
        var index = _items.IndexOf(item);

        _items[index] = (T)entity.Clone();
    }
}
