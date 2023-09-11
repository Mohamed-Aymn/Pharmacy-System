using AuthenticationService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthenticationService.Services;

public class MongoDBService
{
    private readonly IMongoCollection<User> _userCollection;

    public MongoDBService(
    )
    {
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var settings = MongoClientSettings.FromConnectionString(MyConfig.GetValue<string>("MongoDB:ConnectionURI"));
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        IMongoDatabase database = client.GetDatabase(MyConfig.GetValue<string>("MongoDB:DatabaseName"));
        _userCollection = database.GetCollection<User>(MyConfig.GetValue<string>("MongoDB:CollectionName"));
        try
        {
            var result = client.GetDatabase("RestaurantSystem").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public async Task CreateAsync(User user)
    {
        await _userCollection.InsertOneAsync(new User
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        });
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var filter = Builders<User>.Filter
    .Eq(r => r.Name, email);

        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(ObjectId id)
    {
        // get a specific user by using filter method
        FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
        // delete filtered one
        await _userCollection.DeleteOneAsync(filter);
    }

    public async Task<UpdateResult> UpdateAsync(ObjectId id, User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);

        var update = Builders<User>.Update
            .Set(user => user.Name, user.Name)
            .Set(user => user.Email, user.Email)
            .Set(user => user.Password, user.Password);

        return await _userCollection.UpdateOneAsync(filter, update);
    }
}