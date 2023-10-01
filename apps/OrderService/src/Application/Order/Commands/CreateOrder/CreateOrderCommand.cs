using OrderService.Domain.Order.Entites;

namespace OrderService.Application.Order.Commands.CreateOrder;

public class CreateOrderCommand
{
    public string Restaurant { get; set; }
    public string DeliveryAddress { get; set; }
    public double Price { get; set; }
    public List<OrderItem> Items { get; set; }
    public string TrackingId { get; set; }
    public string OrderStatus { get; set; }
    public CreateOrderCommand(string restaurant, string deliveryAddress, double price, List<OrderItem> items, string trackingId, string orderStatus)
    {
        Restaurant = restaurant;
        DeliveryAddress = deliveryAddress;
        Price = price;
        Items = items;
        TrackingId = trackingId;
        OrderStatus = orderStatus;
    }
}