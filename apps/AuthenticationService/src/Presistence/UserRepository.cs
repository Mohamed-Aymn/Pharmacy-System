using AuthenticationService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthenticationService.Presistence;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(IMongoDbContext dbContext)
    {
        _userCollection = dbContext.UsersCollection;
    }
    public async Task Add(User user)
    {
        await _userCollection.InsertOneAsync(user);
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<User> GetByEmail(string email)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Email, email);
        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }
    public async Task<User> GetById(string id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id.ToString(), id);
        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }
    public async Task Delete(string id)
    {
        // get a specific user by using filter method
        FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
        // delete filtered one
        await _userCollection.DeleteOneAsync(filter);
    }
    public async Task<UpdateResult> UpdateAsync(string id, User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id.ToString(), id);

        var update = Builders<User>.Update
            .Set(user => user.Name, user.Name)
            .Set(user => user.Email, user.Email)
            .Set(user => user.Password, user.Password);

        return await _userCollection.UpdateOneAsync(filter, update);
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }
}