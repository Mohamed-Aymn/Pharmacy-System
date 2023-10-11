using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using OrderService.Application.Order.Commands.Create;
using OrderService.Application.Order.Common;

namespace OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {

        // services.AddMediatR(typeof(CreateOrderCommandHanldler));


        // services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        // return services;


        var assembly = Assembly.GetExecutingAssembly();
        // return services.AddMediatR(assembly);
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<IRequestHandler<CreateOrderCommand, OrderResult>, CreateOrderCommandHandler>();


        return services;
    }
}