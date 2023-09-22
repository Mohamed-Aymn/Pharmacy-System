using AuthenticationService.Models;
using MongoDB.Driver;

namespace AuthenticationService.Presistence;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<List<User>> GetAllAsync();
    Task<User> GetByEmail(string email);
    Task<User> GetById(string id);
    Task DeleteAsync(string id);
    Task<UpdateResult> UpdateAsync(string id, User user);
}