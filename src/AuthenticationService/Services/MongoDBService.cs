using AuthenticationService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthenticationService.Services;

public class MongoDBService
{
    private readonly IMongoCollection<User> _userCollection;
    private readonly ILogger _logger;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings,
        ILogger<MongoDBService> logger
    )
    {
        _logger = logger;
        // _logger.LogInformation(mongoDBSettings);
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


        // MongoClient client = new(MyConfig.GetValue<string>("MongoDB:ConnectionURI"));


        var settings = MongoClientSettings.FromConnectionString(MyConfig.GetValue<string>("MongoDB:ConnectionURI"));
        // Set the ServerApi field of the settings object to Stable API version 1
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        // Create a new client and connect to the server
        var client = new MongoClient(settings);
        // Send a ping to confirm a successful connection
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

    public async Task<List<User>> GetAsync()
    {
        return await _userCollection.Find(new BsonDocument()).ToListAsync();
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