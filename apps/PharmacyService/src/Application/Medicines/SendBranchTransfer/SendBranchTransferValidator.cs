using FluentValidation;
using PharmacyService.Application.Medicines.Create;

namespace PharmacyService.Application.Medicines.SendBranchTransfer;

public class DispenseMedicineValidator : AbstractValidator<DispenseMedicineDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.MedicinesName).NotNull();
    RuleFor(m => m.PharmacistId).NotNull();
    RuleFor(m => m.BranchId).NotNull();
  }
}