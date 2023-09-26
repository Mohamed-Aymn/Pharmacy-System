namespace Application.Common.Interfaces.Persistance;

public interface IRepository<T>
{
    Task<T> GetById(string id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(string id);
}