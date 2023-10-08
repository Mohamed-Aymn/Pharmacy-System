using OrderService.Domain.Common.Models;
using OrderService.Domain.Customer.ValueObjects;

namespace OrderService.Domain.Customer.Entites;

public class Customer : AggregateRoot<CustomerId, Guid>
{
    public Customer(CustomerId id) : base(id)
    {
    }
    public List<AddressId> AddressIds { set; get; } = new();
}