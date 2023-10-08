using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Restaurant.ValueObjects;

public class RestaurantId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    public RestaurantId(Guid value)
    {
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
