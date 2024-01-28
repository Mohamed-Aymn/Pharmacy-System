using FluentValidation;
using PharmacyService.Application.Branches.Create;
using PharmacyService.Application.Medicines.Create;

namespace BranchService.Application.Medicines.DirectSearch;

public class DispenseMedicineValidator : AbstractValidator<DirectSearchDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.BarCode).NotNull();
  }
}