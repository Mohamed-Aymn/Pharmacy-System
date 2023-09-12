using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public sealed class OrderId : ValueObject
{
    public Guid Value { get; }
    public OrderId(Guid value)
    {
        Value = value;
    }

    // this creates new OrderId object
    public static OrderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
