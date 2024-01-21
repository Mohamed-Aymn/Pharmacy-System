using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Restaurant.ValueObjects;

namespace OrderService.Domain.Restaurant.Entites;

public class Restaurant : AggregateRoot<RestaurantId, Guid>
{
    public Restaurant(
        List<ItemId> items, 
        bool active,
        RestaurantId id = null!
        ) : base(id ?? new RestaurantId(Guid.NewGuid()))
    {
        Items = items;
        Active = active;
    }
    public List<ItemId> Items { set; get; }
    public bool Active { set; get; }
}
