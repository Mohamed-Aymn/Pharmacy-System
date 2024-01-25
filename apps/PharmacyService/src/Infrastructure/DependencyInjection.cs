using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Infrastructure.Persistence;

namespace PharmacyService.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
  {
    // repos
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    // db context
    services.AddDbContext<PharmacyServiceDbContext>(options => options.UseNpgsql("User ID=postgres;Password=postgres8*;Host=localhost;Port=5432;Database=Pharmacy;"));
    services.AddScoped<PharmacyServiceDbContext>();

    return services;
  }
}