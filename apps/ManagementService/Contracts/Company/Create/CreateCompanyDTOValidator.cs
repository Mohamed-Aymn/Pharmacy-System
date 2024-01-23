using FluentValidation;

namespace ManagementService.Contracts.Company.Create;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyDTO>
{
  public CreateCompanyValidator()
  {
    RuleFor(M => M.Name)
      .NotNull();

    RuleFor(M => M.PhoneNumber)
      .NotNull()
      .Must(i => i.Length is 11).WithMessage("Should be 11 digits")
      .Must(i => i[0] == '0' && i[1] == '1').WithMessage("Should start with 01");

    RuleFor(M => M.Email)
      .NotNull()
      .EmailAddress().WithMessage("Not a valid email address");

    RuleFor(M => M.PaymentShares)
        .NotNull();
  }
}