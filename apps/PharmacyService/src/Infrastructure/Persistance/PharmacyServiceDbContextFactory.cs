using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PharmacyService.Infrastructure.Persistence;

namespace PharmacyService.Infrastructure;

public class PharmacyServiceDbContextFactory : IDesignTimeDbContextFactory<PharmacyServiceDbContext>
{
  public PharmacyServiceDbContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

    var connectionString = configuration.GetConnectionString("DefaultConnection");

    var optionsBuilder = new DbContextOptionsBuilder<PharmacyServiceDbContext>()
        .UseNpgsql(connectionString);

    return new PharmacyServiceDbContext(optionsBuilder.Options);
  }
}