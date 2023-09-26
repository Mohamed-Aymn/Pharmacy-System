using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.Entites;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Domain.Order;

// this is order aggregate root file
// sealed class is used to prevent inheritance
public sealed class Order : AggregateRoot<OrderId>
{
    public Order(OrderId id) : base(id)
    {
    }

    public CustomerId CustomerId { get; set; }
    public string Restaurant { get; set; }
    public string DeliveryAddress { get; set; }
    public double Price { get; set; }
    public List<OrderItem> Items { get; set; }
    public string TrackingId { get; set; }
    public string OrderStatus { get; set; }
    public List<String> FailureMessages { get; set; }
}