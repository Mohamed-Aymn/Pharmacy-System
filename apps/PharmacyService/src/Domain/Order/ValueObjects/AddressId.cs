using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class AddressId : ValueObject
{
    public Guid Id { get; set; }
    public AddressId(Guid id)
    {
        Id = id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
