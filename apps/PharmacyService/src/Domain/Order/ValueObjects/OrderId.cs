using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public sealed class OrderId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
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
