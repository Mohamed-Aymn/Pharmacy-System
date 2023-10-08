using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Common.Interfaces.Persistence;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddDbContext<OrderServiceDbContext>();

        return services;
    }
}