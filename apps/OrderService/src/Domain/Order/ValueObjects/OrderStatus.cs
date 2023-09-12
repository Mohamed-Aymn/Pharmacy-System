using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class OrderStatus : ValueObject
{
    public List<Order> Pendings { get; set; } = new List<Order>();
    public List<Order> Paid { get; set; } = new List<Order>();
    public List<Order> Approved { get; set; } = new List<Order>();
    public List<Order> Cancelling { get; set; } = new List<Order>();
    public List<Order> Cancelled { get; set; } = new List<Order>();
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Pendings;
        yield return Paid;
        yield return Approved;
        yield return Cancelling;
        yield return Cancelled;
    }
}
