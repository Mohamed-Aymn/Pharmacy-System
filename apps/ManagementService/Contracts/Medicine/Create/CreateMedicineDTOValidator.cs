using FluentValidation;

namespace ManagementService.Contracts.Medicine.Create;

public class CreateMedicineValidator : AbstractValidator<CreateMedicineDTO>
{
  public CreateMedicineValidator()
  {
    RuleFor(M => M.Name)
      .NotNull();

    RuleFor(M => M.BarCode)
      .NotNull()
      .Must(i => i.Length is 12).WithMessage("Should be 12 digits");

    RuleFor(M => M.MedicineType)
      .NotNull();
  }
}