using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.ValueObjects;

public class OrderItem : Entity<OrderItemId>
{
    public OrderItem(OrderItemId id) : base(id)
    {
    }
    public OrderItemId OrderItemId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public Money Price { get; set; }
    public Money SubTotal { get; set; }
}
