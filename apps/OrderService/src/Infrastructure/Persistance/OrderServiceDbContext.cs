using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderService.Domain.Address.Entities;
using OrderService.Domain.Customer.Entites;
using OrderService.Domain.Item.Entites;
using OrderService.Domain.Order.Entites;
using OrderService.Domain.Restaurant.Entites;

namespace OrderService.Infrastructure.Persistence;

public class OrderServiceDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    // aggregates
    public DbSet<Order> Order { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Item> Item { get; set; }

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