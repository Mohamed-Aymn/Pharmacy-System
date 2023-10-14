using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        // db context
        services.AddDbContext<OrderServiceDbContext>();

        return services;
    }
}