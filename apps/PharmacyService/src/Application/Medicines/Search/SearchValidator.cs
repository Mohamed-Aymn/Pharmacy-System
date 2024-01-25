using FluentValidation;
using PharmacyService.Application.Medicines.Create;

namespace PharmacyService.Application.Medicines.Search;

public class DispenseMedicineValidator : AbstractValidator<SearchDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.MedicineName).NotNull();
  }
}