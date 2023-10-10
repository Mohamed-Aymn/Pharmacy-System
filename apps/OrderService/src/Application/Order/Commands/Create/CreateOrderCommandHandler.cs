using OrderService.Domain.Order.ValueObjects;
using OrderNamespace = OrderService.Domain.Order.Entites;
namespace OrderService.Application.Order.Commands.Create;

public class CreateOrderCommandHanldler
{
    public Task Handle(CreateOrderCommand command)
    {
        // create order (generate unique id & presist in database)
        // OrderNamespace.Order order = new(
        //     orderStatus: "Pending",
        //     price: new Price(10.99),
        //     address: "123 Main St",
        //     RestaurantId: RestaurantId,
        //     CustomerId: CustomerId);

        return null;
    }
}