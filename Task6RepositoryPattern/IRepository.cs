namespace Task6RepositoryPattern;

internal interface IRepository<T> where T : Entity
{
    T GetById(int id);
    IList<T> FindAll();
    T Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
