using System.Data.Common;
using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class ProductId : ValueObject
{
    public Guid Id { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
