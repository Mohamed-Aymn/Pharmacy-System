namespace OrderService.Application.Order.Commands.Create;

public record CreateOrderRequest(
    Guid Restaurant,
    DeliveryAddress DeliveryAddress,
    List<Guid> Items,
    string OrderStatus
);

public record DeliveryAddress(
    Guid Id,
    string Street,
    int PostalCode,
    string City
);