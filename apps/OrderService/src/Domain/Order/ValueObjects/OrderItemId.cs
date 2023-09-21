using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class OrderItemId : ValueObject
{
    private Guid Id { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}