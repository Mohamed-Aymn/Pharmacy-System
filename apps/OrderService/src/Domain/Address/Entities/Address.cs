using OrderService.Domain.Address.ValueObjects;
using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;

namespace OrderService.Domain.Address.Entities;

public sealed class Address : AggregateRoot<AddressId, Guid>
{
    public Address(AddressId id) : base(id)
    {
    }
    public CustomerId CustomerId { get; set; }
    public String Street { get; set; }
    public String PostalCode { get; set; }
    public String City { get; set; }
}