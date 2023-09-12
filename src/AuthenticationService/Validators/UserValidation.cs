using AuthenticationService.Models;
using FluentValidation;

namespace AuthenticationService.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        // RuleFor(u => u.Name).NotNull();
        RuleFor(u => u.Password).NotNull();
        RuleFor(u => u.Email).NotNull();
    }
}