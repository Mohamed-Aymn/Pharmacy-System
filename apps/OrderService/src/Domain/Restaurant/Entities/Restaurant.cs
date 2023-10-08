using OrderService.Domain.Common.Models;
using OrderService.Domain.Restaurant.ValueObjects;

namespace OrderService.Domain.Restaurant.Entites;

public class Restaurant : AggregateRoot<RestaurantId, Guid>
{
    public Restaurant(RestaurantId id) : base(id)
    {
    }
    public List<Item> Items { set; get; }
    public bool Active { set; get; }
}
