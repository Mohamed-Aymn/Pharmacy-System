using OrderNamespace = OrderService.Domain.Order;

namespace OrderService.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    OrderNamespace.Order? GerOrderById(string id);
    void Add(OrderNamespace.Order order);
}