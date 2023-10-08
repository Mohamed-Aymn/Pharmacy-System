using OrderService.Domain.Order.Entites;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Application.Order.Commands.CreateOrder;

public record CreateOrderCommand(
    CustomerId CustomerId,
    string Restaurant,
    string DeliveryAddress,
    double Price,
    List<OrderItem> Items,
    string TrackingId,
    string OrderStatus
);