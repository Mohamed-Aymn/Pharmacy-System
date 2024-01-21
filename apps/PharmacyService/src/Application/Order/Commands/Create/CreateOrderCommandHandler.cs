using MapsterMapper;
using MediatR;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Application.Order.Common;
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
    private readonly IMapper _mapper;
    public CreateOrderCommandHandler(
        IAddressRepository addressRepository,
        IRestaurantRepository restaurantRepository,
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _restaurantRepository = restaurantRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // get customerId from token (now it's just a mock customer id)
        CustomerId customerId = new();

        // search if address id already exists
        Domain.Address.Entities.Address? deliveryAddress = await _addressRepository.GetByIdAsync(request.Address.Id);
        if (deliveryAddress! == null!)
        {
            deliveryAddress = _mapper.Map<Domain.Address.Entities.Address>(deliveryAddress!);
            await _addressRepository.AddAsync(deliveryAddress);
        }

        // calculate price
        Price price = new(0, "USD");

        // create order (generate unique id & presist in database)
        Restaurant? restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);
        OrderNamespace.Order order = new(
            orderStatus: "new",
            price: price,
            addressId: new AddressId(deliveryAddress.Id.Value),
            restaurant: new RestaurantId(restaurant.Id.Value),
            customerId: customerId);
        await _orderRepository.AddAsync(order);

        return new OrderResult();
    }
}