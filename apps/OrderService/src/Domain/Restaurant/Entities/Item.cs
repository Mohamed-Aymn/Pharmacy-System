using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Restaurant.ValueObjects;

namespace OrderService.Domain.Restaurant.Entites;
public class Item : Entity<ItemId>
{
    public Item(ItemId id) : base(id)
    {
    }
    public string Name { get; set; }
    public Price Price { get; set; }
}
