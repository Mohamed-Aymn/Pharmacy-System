using FluentValidation;
using PharmacyService.Application.Medicines.Create;
namespace BranchService.Application.Branches.Create;

public class DispenseMedicineValidator : AbstractValidator<DispenseMedicineDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.MedicineIds).NotNull();
    RuleFor(m => m.PharmacistId).NotNull();
    RuleFor(m => m.BranchId).NotNull();
  }
}