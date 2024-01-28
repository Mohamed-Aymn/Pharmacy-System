using FluentValidation;
using PharmacyService.Application.Medicines.Create;

namespace PharmacyService.Application.Medicines.ReceiveBranchTransfer;
public class DispenseMedicineValidator : AbstractValidator<ReceiveBranchTransferDto>
{
  public DispenseMedicineValidator()
  {
    RuleFor(m => m.TransferCode).NotNull();
    RuleFor(m => m.PharmacistId).NotNull();
  }
}