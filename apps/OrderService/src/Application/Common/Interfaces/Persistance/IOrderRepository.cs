using OrderNamespace = OrderService.Domain.Order;

namespace OrderService.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Task Add(OrderNamespace.Order order);
    Task<OrderNamespace.Order?> GerOrderById(string id);
}