using FluentValidation;

namespace OrderService.Application.Order.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.RestaurantId).NotNull();

        RuleFor(o => o.Address.Id).NotNull();
        RuleFor(o => o.Address.City).NotNull();
        RuleFor(o => o.Address.PostalCode).NotNull().NotEqual(0);
        RuleFor(o => o.Address.Street).NotNull();

        RuleFor(o => o.Items).Must(i => i.Count is not 0);
    }
}