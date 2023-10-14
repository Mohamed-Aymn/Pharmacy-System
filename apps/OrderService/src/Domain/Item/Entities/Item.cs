using OrderService.Domain.Common.Models;
using OrderService.Domain.Common.ValueObjects;
using ItemNamespace = OrderService.Domain.Item.ValueObjects;

namespace OrderService.Domain.Item.Entites;

public class Item : AggregateRoot<ItemNamespace.ItemId, Guid>
{
    public Item(ItemNamespace.ItemId id) : base(id)
    {
    }
    public string Name { get; set; }
    public Price Price { get; set; }
}