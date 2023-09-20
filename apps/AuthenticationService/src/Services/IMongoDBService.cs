using AuthenticationService.Models;
using MongoDB.Driver;

namespace AuthenticationService.Services;

public interface IMongoDBService
{
    public Task CreateAsync(User user);

    public Task<List<User>> GetAllAsync();

    public Task<User> GetByEmail(string email);

    public Task<User> GetById(string id);

    public Task DeleteAsync(string id);

    public Task<UpdateResult> UpdateAsync(string id, User user);
}