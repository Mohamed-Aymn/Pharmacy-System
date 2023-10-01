using OrderService.Domain.Order;

namespace OrderService.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Order? GerOrderById(string id);
    void Add(Order order);
}