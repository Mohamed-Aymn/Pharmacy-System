using MediatR;
using OrderService.Application.Order.Common;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderCommand(
    CustomerId CustomerId,
    OrderService.Domain.Restaurant.ValueObjects.RestaurantId RestaurantId,
    Address Address,
    Price Price,
    List<Guid> Items,
    string OrderStatus
) : IRequest<OrderResult>;

public record Address(
    Guid Id,
    string Street,
    int PostalCode,
    string City
);