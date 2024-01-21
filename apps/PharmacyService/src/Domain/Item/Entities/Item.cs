using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using ItemNamespace = OrderService.Domain.Item.ValueObjects;

namespace OrderService.Domain.Item.Entites;

public class Item : AggregateRoot<ItemNamespace.ItemId, Guid>
{
    public Item(
        string name,
        Price price,
        ItemNamespace.ItemId id = null!
        ) : base(id ?? new ItemNamespace.ItemId(Guid.NewGuid()))
    {
        Name = name;
        Price = price;
    }
    public string Name { get; set; }
    public Price Price { get; set; }
}