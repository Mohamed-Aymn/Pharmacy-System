using FluentValidation;

namespace OrderService.Contracts.Order;

public class CreateOrderRequestValidatior : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidatior()
    {
        RuleFor(o => o.Restaurant).NotNull();
        RuleFor(o => o.DeliveryAddress).NotNull();
        RuleFor(o => o.Price).NotNull().NotEqual(0);
    }
}
