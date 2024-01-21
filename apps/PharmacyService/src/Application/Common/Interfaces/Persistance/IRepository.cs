namespace Application.Common.Interfaces.Persistance;

public interface IRepository<T, TId>
{
    Task<T?> GetByIdAsync(TId id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(TId id);
}