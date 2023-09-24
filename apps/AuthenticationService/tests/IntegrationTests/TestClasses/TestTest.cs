using AuthenticationService.Models;
using AuthenticationService.Presistence;
using IntegrationTests.Fixtures;

namespace IntegrationTests.TestClasses;

public class TestTest : IClassFixture<DbFixture>
{
    private readonly DbFixture _fixture;

    public TestTest(DbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task InsertUserTest()
    {
        UserRepository sut = new(_fixture.DbContext);
        User user = new(
            "test",
            "1234567",
            "test@test.com"
        );
        await sut.Add(user);


        List<User> allUsers = await sut.GetAllAsync();
        Assert.NotNull(allUsers);
    }

    // private readonly MongoDbContext _dbContext;
    // public TestTest()
    // {
    //     MongoDbContextSettings contextSettings = new(
    //         "mongodb://root:example@localhost:27019",
    //         $"test_db_{Guid.NewGuid()}"
    //     );
    //     _dbContext = new(contextSettings);
    // }

    // [fact]
    // public async task insertusertest()
    // {
    //     userrepository sut = new(_dbcontext);
    //     user user = new(
    //         "test",
    //         "1234567",
    //         "test@test.com"
    //     );
    //     await sut.add(user);


    //     list<user> allusers = await sut.getallasync();
    //     assert.notnull(allusers);
    // }
}