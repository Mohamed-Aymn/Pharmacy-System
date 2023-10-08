using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderService.Domain.Order;
using OrderNamespace = OrderService.Domain.Order;

namespace OrderService.Infrastructure.Persistence;

public class OrderServiceDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    // aggregates
    public DbSet<OrderNamespace.Order> Order { get; set; }

    public OrderServiceDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect with connection string
        options.UseNpgsql(Configuration.GetConnectionString("PgConnectionString"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderServiceDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}