using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Customer.ValueObjects;

public class AddressId : ValueObject
{
    private Guid Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}