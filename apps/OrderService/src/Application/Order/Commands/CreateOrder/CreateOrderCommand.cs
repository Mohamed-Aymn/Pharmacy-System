using OrderService.Domain.Order.Entites;

namespace OrderService.Application.Order.Commands.CreateOrder;

public record CreateOrderCommand(
    string Restaurant,
    string DeliveryAddress,
    double Price,
    List<OrderItem> Items,
    string TrackingId,
    string OrderStatus
);