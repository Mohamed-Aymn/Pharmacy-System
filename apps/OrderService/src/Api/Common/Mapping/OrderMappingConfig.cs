using Mapster;
using OrderService.Application.Order.Commands.Create;
using OrderService.Domain.Order.ValueObjects;
using RestaurantNamespace = OrderService.Domain.Restaurant.ValueObjects;

namespace OrderService.Api.Common.Mapping;

public class OrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
            .Map(dest => dest.RestaurantId, src => src.RestaurantId)
            .Map(dest => dest.Address, src => src.Address);
    }
}