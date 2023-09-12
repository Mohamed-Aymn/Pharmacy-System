using AuthenticationService.Contracts;
using FluentValidation;

namespace AuthenticationService.Validators;

class SigninValidator : AbstractValidator<SigninRequest>
{
    public SigninValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .NotNull();
        RuleFor(u => u.Password)
            .NotNull();
    }
}