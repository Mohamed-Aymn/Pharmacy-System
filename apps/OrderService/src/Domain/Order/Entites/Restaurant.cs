using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Domain.Order.Entites;

public class Restaurant : AggregateRoot<RestaurantId>
{
    public Restaurant(RestaurantId id) : base(id)
    {
    }
    public RestaurantId RestaurantId { get; }
    public List<Product> Products { set; get; }
    public bool Active { set; get; }
}
