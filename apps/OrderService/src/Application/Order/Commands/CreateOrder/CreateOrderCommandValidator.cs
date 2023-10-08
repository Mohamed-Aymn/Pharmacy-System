using FluentValidation;

namespace OrderService.Application.Order.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Restaurant).NotNull();
        RuleFor(o => o.DeliveryAddress).NotNull();
        RuleFor(o => o.Price).NotNull().NotEqual(0);
    }
}