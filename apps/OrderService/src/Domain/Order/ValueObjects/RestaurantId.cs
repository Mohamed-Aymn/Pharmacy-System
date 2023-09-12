using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class RestaurantId : ValueObject
{
    public Guid Id { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
