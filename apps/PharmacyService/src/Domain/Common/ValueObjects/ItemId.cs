using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Common.ValueObjects;

public class ItemId : ValueObject
{
    private Guid Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}