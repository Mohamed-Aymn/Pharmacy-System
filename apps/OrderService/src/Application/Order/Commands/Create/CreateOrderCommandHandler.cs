using Mapster;
using MediatR;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Application.Order.Common;
using OrderService.Domain.Address.Entities;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Order.ValueObjects;
using OrderService.Domain.Restaurant.Entites;
using OrderNamespace = OrderService.Domain.Order.Entites;

namespace OrderService.Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResult>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IOrderRepository _orderRepository;
    public CreateOrderCommandHandler(
        IAddressRepository addressRepository,
        IRestaurantRepository restaurantRepository,
        IOrderRepository orderRepository)
    {
        _addressRepository = addressRepository;
        _restaurantRepository = restaurantRepository;
        _orderRepository = orderRepository;
    }

    public async Task<OrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // get customerId from token (now it's just a mock customer id)
        CustomerId customerId = new();

        // search if address id already exists
        var deliveryAddress = await _addressRepository.GetByIdAsync(request.DeliveryAddress.Id);
        if (deliveryAddress! == null!)
        {
            deliveryAddress = request.DeliveryAddress.Adapt<Address>();
            await _addressRepository.AddAsync(deliveryAddress);
        }

        // calculate price
        Price price = new(0, "USD");
        Restaurant? restaurant = await _restaurantRepository.GetByIdAsync(request.Restaurant);
        for (int i = 0; i < restaurant!.Items.Count; i++)
        {
            price.Amount += restaurant.Items[i].Price.Amount;
        }

        // create order (generate unique id & presist in database)
        OrderNamespace.Order order = new(
            orderStatus: "new",
            price: price,
            deliveryAddress: new AddressId(deliveryAddress.Id.Value),
            restaurant: new RestaurantId(restaurant.Id.Value),
            customerId: customerId);
        await _orderRepository.AddAsync(order);

        return new OrderResult();
    }
}