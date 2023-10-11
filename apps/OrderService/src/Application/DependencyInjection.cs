using Microsoft.Extensions.DependencyInjection;
using MediatR;
using OrderService.Application.Order.Commands.Create;
using OrderService.Application.Order.Common;

namespace OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<IRequestHandler<CreateOrderCommand, OrderResult>, CreateOrderCommandHandler>();
        return services;
    }
}