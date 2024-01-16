using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Address.Entities;
using OrderService.Domain.Customer.Entites;
using OrderService.Domain.Item.Entites;
using OrderService.Domain.Order.Entites;
using OrderService.Domain.Restaurant.Entites;

namespace OrderService.Infrastructure.Persistence;

public class OrderServiceDbContext : DbContext
{
    public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderServiceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    // aggregates
    public DbSet<Order> Order { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Item> Item { get; set; }
}