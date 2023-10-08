using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Common.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Id { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
