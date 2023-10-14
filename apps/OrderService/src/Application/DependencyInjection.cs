using Microsoft.Extensions.DependencyInjection;
using MediatR;
using OrderService.Application.Common.Behaviors;
using FluentValidation;

namespace OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        // mediator
        services.AddMediatR(typeof(DependencyInjection));
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}