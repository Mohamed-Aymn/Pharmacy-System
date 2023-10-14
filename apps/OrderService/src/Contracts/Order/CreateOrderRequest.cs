namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderRequest(
    Guid RestaurantId,
    Address Address,
    List<Guid> Items,
    string OrderStatus
);

public record Address(
    Guid Id,
    string Street,
    int PostalCode,
    string City
);