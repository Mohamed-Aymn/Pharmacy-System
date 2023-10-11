using MediatR;
using OrderService.Application.Order.Common;
using OrderService.Domain.Common.ValueObjects;

namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderCommand(
    CustomerId CustomerId,
    Guid Restaurant,
    DeliveryAddress DeliveryAddress,
    double Price,
    List<Guid> Items,
    string TrackingId,
    string OrderStatus
) : IRequest<OrderResult>;

public record DeliveryAddress(
    Guid Id,
    string Street,
    int PostalCode,
    string City
);