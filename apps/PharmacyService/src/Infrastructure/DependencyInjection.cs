using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Infrastructure;
using PharmacyService.Infrastructure.Persistence;

namespace OrderService.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
  {
    // repos
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    // db context
    services.AddScoped<PharmacyServiceDbContext>();

    return services;
  }
}