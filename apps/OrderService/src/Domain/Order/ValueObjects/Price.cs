using OrderService.Domain.Common.Models;

namespace OrderService.Domain.Order.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; set; } = 0;
    public string Currency { get; set; }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}