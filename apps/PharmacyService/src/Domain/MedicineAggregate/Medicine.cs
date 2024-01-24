using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.MedicineAggregate;

public class Medicine : AggregateRoot<MedicineId>
{
  public Medicine(MedicineId id) : base(id) { }

  public string Name { get; set; }
  public string BarCode { get; set; }
  public MedicineType MedicineType { get; set; }
  public BranchId BranchId { get; set; }
}