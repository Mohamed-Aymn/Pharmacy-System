using FluentValidation;

namespace ManagementService.Contracts.Medicine.Update;

public class UpdateMedicineValidator : AbstractValidator<UpdateMedicineDTO>
{
  public UpdateMedicineValidator()
  {
    RuleFor(M => M.Name).NotNull();
    RuleFor(M => M.BarCode).NotNull().Must(i => i.Length is 12).WithMessage("Phone number should be 12 digits");
    RuleFor(M => M.MedicineType).NotNull();
  }
}