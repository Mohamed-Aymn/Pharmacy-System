using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Address.ValueObjects;

public sealed class AddressId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    public AddressId(Guid value)
    {
        Value = value;
    }

    // this creates new AddressId object
    public static AddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
