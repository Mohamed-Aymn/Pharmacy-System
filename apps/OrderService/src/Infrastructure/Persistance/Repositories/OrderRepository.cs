using OrderService.Application.Common.Interfaces.Persistence;
using OrderService.Domain.Order;

namespace OrderService.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public OrderRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Order order)
    {
        await _dbContext.Order.AddAsync(order);
    }

    public async Task<Order?> GerOrderById(string id)
    {
        return await _dbContext.Order.FindAsync(id);
    }
}