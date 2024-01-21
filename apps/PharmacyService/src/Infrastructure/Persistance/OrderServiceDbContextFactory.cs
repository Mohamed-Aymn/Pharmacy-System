using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Infrastructure;

public class OrderServiceDbContextFactory : IDesignTimeDbContextFactory<OrderServiceDbContext>
{
    public OrderServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderServiceDbContext>()
            .UseNpgsql("Host=localhost; Database=order_service; Username=postgres; Password=postgres8*");

        return new OrderServiceDbContext(optionsBuilder.Options);
    }
}