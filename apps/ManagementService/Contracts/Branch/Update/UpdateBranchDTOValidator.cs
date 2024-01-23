using FluentValidation;

namespace ManagementService.Contracts.Branch.Update;

public class UpdateBranchValidator : AbstractValidator<UpdateBranchDTO>
{
  public UpdateBranchValidator()
  {
    RuleFor(M => M.Name).NotNull();
    RuleFor(M => M.PhoneNumber).NotNull().Must(i => i.Length is 11).WithMessage("Phone number should be 11 digits");
    RuleFor(M => M.Address).NotNull();
  }
}