using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.ValueObjects;

public class Customer : AggregateRoot<CustomerId>
{
    public CustomerId CustomerId { get; }
    public Customer(CustomerId id) : base(id)
    {
    }
}
