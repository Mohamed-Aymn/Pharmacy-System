using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Common.ValueObjects;

public class CustomerId : ValueObject
{
    public CustomerId(Guid id)
    {
        Id = id;
    }
    public CustomerId()
    {
        Id = Guid.NewGuid();
    }


    public Guid Id { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
