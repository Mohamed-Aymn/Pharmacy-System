namespace OrderService.Contracts;

public record CreateOrderRequest(
    string Restaurant,
    string DeliveryAddress,
    double Price
);