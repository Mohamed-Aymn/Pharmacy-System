using OrderService.Domain.Address.ValueObjects;
using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;

namespace OrderService.Domain.Address.Entities;

public sealed class Address : AggregateRoot<AddressId, Guid>
{
    public Address(
        CustomerId customerId,
        string street,
        int postalCode,
        string city,
        AddressId id = null!
        ) : base(id ?? AddressId.CreateUnique())
    {
        CustomerId = customerId;
        Street = street;
        PostalCode = postalCode;
        City = city;
    }

    public CustomerId CustomerId { get; set; }
    public string Street { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
}