public interface IRepository<T>
{
    Task<T> GetById(string id);
    Task Add(T user);
    Task Update(T user);
    Task Delete(string id);
}