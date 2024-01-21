using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Customer.ValueObjects;

public class CustomerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    public CustomerId(Guid value)
    {
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
