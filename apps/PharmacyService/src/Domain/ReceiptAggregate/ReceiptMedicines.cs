using PharmacyService.Domain.ReceiptAggregate;
using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.ReceiptMedicinesAggregate;

public class ReceiptMedicines : Entity<ReceiptId>
{
  public ReceiptMedicines(ReceiptId id) : base(id) { }

  public MedicineId Medicine { get; set; }
}