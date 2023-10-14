using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Domain.Order.Entites;

public sealed class Order : AggregateRoot<OrderId, Guid>
{
    public Order(
        string orderStatus,
        Price price,
        AddressId deliveryAddress,
        RestaurantId restaurant,
        CustomerId customerId,
        OrderId id = null!
        ) : base(id ?? OrderId.CreateUnique())
    {
        OrderStatus = orderStatus;
        Price = price;
        AddressId = deliveryAddress;
        RestaurantId = restaurant;
        CustomerId = customerId;
    }

    public CustomerId CustomerId { get; set; }
    public RestaurantId RestaurantId { get; set; }
    public AddressId AddressId { get; set; }
    public Price Price { get; set; }
    public List<ItemId> Items { get; set; } = new();
    public string OrderStatus { get; set; }
    public List<string> FailureMessages { get; set; } = new();
}