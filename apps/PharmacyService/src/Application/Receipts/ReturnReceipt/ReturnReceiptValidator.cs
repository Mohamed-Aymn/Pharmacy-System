using FluentValidation;

namespace PharmacyService.Application.Receipts.ReturnReceipt;
public class ReturnReceiptValidator : AbstractValidator<ReturnReceiptDto>
{
  public ReturnReceiptValidator()
  {
    RuleFor(m => m.MedicinesName).NotNull();
    RuleFor(m => m.CashierId).NotNull();
  }
}