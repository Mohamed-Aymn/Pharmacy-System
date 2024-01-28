using PharmacyService.Domain.ReceiptMedicinesAggregate;
using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.ReceiptAggregate;

public class Receipt : AggregateRoot<ReceiptId>
{
  public Receipt(ReceiptId id) : base(id) { }

  // public ReceiptMedicines ReceiptMedicines { get; set; }
  public BranchId BranchId { get; set; }
  public PharmacistId PharmacistId { get; set; }
  public CashierId CashierId { get; set; }
  public string DateAndTime { get; set; }
}