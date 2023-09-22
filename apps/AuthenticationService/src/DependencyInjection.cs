using AuthenticationService.Presistence;

namespace AuthenticationService;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository>(provider =>
        {
            MongoDbContextSettings settings = new(
                "asdf",
                "asdf"
            );
            return new UserRepository(new MongoDbContext(settings));
        });

        return services;
    }
}