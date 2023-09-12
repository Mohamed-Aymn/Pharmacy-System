using OrderService.Domain.Common.Models;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Domain.Order.Entites;
public class Product : Entity<ProductId>
{
    public Product(ProductId id) : base(id)
    {
    }

    public String Name { get; set; }
    public Money Price { get; set; }
}
