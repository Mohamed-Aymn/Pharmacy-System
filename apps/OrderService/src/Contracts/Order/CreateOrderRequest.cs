namespace OrderService.Contracts;

public record CreateOrderRequest(
    string Id,
    string Restaurant,
    string DeliveryAddress,
    double Price
);