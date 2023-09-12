using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class StreetAddress : ValueObject
{
    public Guid Id { get; }
    public String Street { get; set; }
    public String PostalCode { get; set; }
    public String City { get; set; }

    public StreetAddress() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
