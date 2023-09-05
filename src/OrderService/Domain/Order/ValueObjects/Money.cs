using System.Numerics;
using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class Money : ValueObject
{
    public BigInteger Amount { get; set; }
    public Money(BigInteger amount)
    {
        Amount = amount;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}
