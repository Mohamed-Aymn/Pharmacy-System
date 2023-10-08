using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Domain.Order.Entites;

public sealed class Order : AggregateRoot<OrderId, Guid>
{
    public Order(
        OrderId id
        // string orderStatus,
        // string trackingId,
        // double price,
        // string deliveryAddress,
        // string restaurant,
        // CustomerId customerId
        ) : base(id)
    {
        // OrderStatus = orderStatus;
        // TrackingId = trackingId;
        // Price = price;
        // DeliveryAddress = deliveryAddress;
        // Restaurant = restaurant;
        // CustomerId = customerId;
    }

    public CustomerId CustomerId { get; set; }
    public RestaurantId Restaurant { get; set; }
    public string DeliveryAddress { get; set; }
    public Price Price { get; set; }
    public List<ItemId> Items { get; set; } = new();
    public string OrderStatus { get; set; }
    public List<string> FailureMessages { get; set; } = new();
}