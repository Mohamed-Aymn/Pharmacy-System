using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Infrastructure.Broker;
using PharmacyService.Infrastructure.Persistence;

namespace PharmacyService.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
  {
    // repos
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    // db context
    services.AddDbContext<PharmacyServiceDbContext>(options => options.UseNpgsql("User ID=postgres;Password=postgres8*;Host=localhost;Port=5432;Database=Pharmacy;"));
    services.AddScoped<PharmacyServiceDbContext>();

    // message broker
    services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
    services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

    // massTransit
    services.AddMassTransit(busConfigurator =>
    {
      busConfigurator.SetKebabCaseEndpointNameFormatter();

      // busConfigurator.AddConsumer<BranchCreatedEventConsumer>();
      busConfigurator.UsingRabbitMq((context, configurator) =>
      {
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.ReceiveEndpoint("my-queue", ep =>
      {
        ep.PrefetchCount = 16;
        ep.UseMessageRetry(r => r.Interval(2, 100));

        ep.ConfigureConsumers(context);
      });

        configurator.Host(new Uri(settings.Host), h =>
        {
          h.Username(settings.Username);
          h.Password(settings.Password);
        });
      });
    });

    return services;
  }
}