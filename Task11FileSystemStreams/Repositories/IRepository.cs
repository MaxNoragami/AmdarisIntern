using Task11FileSystemStreams.Entities;

namespace Task11FileSystemStreams.Repositories;

public interface IRepository<T> where T : Entity
{
    T GetById(int id);
    IList<T> FindAll();
    T Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
