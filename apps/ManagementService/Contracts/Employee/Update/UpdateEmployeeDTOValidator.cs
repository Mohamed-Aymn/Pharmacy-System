using FluentValidation;

namespace ManagementService.Contracts.Employee.Update;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
{
  public UpdateEmployeeValidator()
  {
    RuleFor(M => M.Name).NotNull();
    RuleFor(M => M.PhoneNumber).NotNull().Must(i => i.Length is 11).WithMessage("Phone number should be 11 digits");
    RuleFor(M => M.Email).NotNull().EmailAddress();
  }
}