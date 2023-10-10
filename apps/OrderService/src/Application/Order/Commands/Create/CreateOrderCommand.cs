using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Restaurant.Entites;

namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderCommand(
    CustomerId CustomerId,
    string Restaurant,
    string DeliveryAddress,
    double Price,
    List<Item> Items,
    string TrackingId,
    string OrderStatus
);