using MediatR;
using OrderService.Application.Order.Common;
using OrderService.Domain.Common.ValueObjects;

namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderCommand(
    CustomerId CustomerId,
    Guid RestaurantId,
    Address Address,
    List<Guid> Items
) : IRequest<OrderResult>;

public record Address(
    Guid Id,
    string Street,
    int PostalCode,
    string City
);