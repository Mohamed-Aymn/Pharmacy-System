using FluentValidation;

namespace PharmacyService.Application.Receipts.CreateReceipt;
public class CreateReceiptValidator : AbstractValidator<CreateReceiptDto>
{
  public CreateReceiptValidator()
  {
    RuleFor(m => m.BranchId).NotNull();
    RuleFor(m => m.PharmacistId).NotNull();
    RuleFor(m => m.MedicinesName).NotNull();
    RuleFor(m => m.CashierId).NotNull();
  }
}