using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Item.ValueObjects;

public class ItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    public ItemId(Guid value)
    {
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
