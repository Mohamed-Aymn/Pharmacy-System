using AuthenticationService.Contracts;
using FluentValidation;

namespace AuthenticationService.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name)
            .NotNull()
            .MinimumLength(2).WithMessage("minimum length is 2 characters");
        RuleFor(u => u.Email)
            .EmailAddress()
            .NotNull();
        RuleFor(u => u.Password)
            .NotNull()
            .MinimumLength(6).WithMessage("password should not be smaller than 6 characters")
            .MaximumLength(17).WithMessage("password should not be greater than 17 characters");
    }
}