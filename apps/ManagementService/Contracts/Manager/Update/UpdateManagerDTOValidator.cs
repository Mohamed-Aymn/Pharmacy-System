using FluentValidation;

namespace ManagementService.Contracts.Manager.Update;

public class UpdateManagerValidator : AbstractValidator<UpdateManagerDTO>
{
  public UpdateManagerValidator()
  {
    RuleFor(M => M.Name).NotNull();
    RuleFor(M => M.PhoneNumber).NotNull().Must(i => i.Length is 11).WithMessage("Phone number should be 11 digits");
    RuleFor(M => M.Email).NotNull().EmailAddress();
  }
}