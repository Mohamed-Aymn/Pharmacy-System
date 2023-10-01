using OrderService.Application.Common.Interfaces.Persistence;
using OrderService.Domain.Order;

namespace OrderService.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    public void Add(Order order)
    {
        throw new NotImplementedException();
    }

    public Order? GerOrderById(string id)
    {
        throw new NotImplementedException();
    }
}