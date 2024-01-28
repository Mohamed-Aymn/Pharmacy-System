using Microsoft.Extensions.DependencyInjection;
using MediatR;
using PharmacyService.Application.Common.Behaviors;
using FluentValidation;

namespace PharmacyService.Application;

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