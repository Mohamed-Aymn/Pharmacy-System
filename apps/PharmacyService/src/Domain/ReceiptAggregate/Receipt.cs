using Microsoft.VisualBasic;
using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.ReceiptAggregate;

public class Receipt : AggregateRoot<ReceiptId>
{
  public Receipt(ReceiptId id) : base(id) { }

  public MedicineId[] MedicineIds { get; set; }
  public BranchId BranchId { get; set; }
  public PharmacistId PharmacistId { get; set; }
  public CashierId CashierId { get; set; }
  public string DateAndTime { get; set; }
}