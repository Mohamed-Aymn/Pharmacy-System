using OrderService.Domain.Common.Models;
using OrderService.Domain.Customer.ValueObjects;

namespace OrderService.Domain.Customer.Entites;

public class Customer : AggregateRoot<CustomerId, Guid>
{
    public Customer(
        List<AddressId> addressIds,
        CustomerId id = null!
        ) : base(id ?? new CustomerId(Guid.NewGuid()))
    {
        AddressIds = addressIds;
    }
    public List<AddressId> AddressIds { set; get; } = new();
}