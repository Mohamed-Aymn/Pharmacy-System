using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.ValueObjects;

public class Order : AggregateRoot<OrderId>
{
    public CustomerId customerId;
    public RestaurantId restaurantId;
    public StreetAddress deliveryAddress;
    public Money price;
    public List<OrderItem> items;

    public TrackingId trackingId;
    public OrderStatus orderStatus;
    public List<String> failureMessages;

    public Order(OrderId id) : base(id)
    {
    }
}
