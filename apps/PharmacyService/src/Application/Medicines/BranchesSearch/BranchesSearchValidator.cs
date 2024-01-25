using FluentValidation;
using PharmacyService.Application.Medicines.BranchesSearch;

namespace BranchService.Application.Medicines.BranchesSearch;

public class DispenseMedicineValidator : AbstractValidator<BranchesSearchDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.MedicineIds).NotNull();
  }
}