using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.BranchAggregate;

public class Branch : AggregateRoot<BranchId>
{
  public Branch(BranchId id) : base(id) { }

  public string Name { get; set; }
  public string Address { get; set; }
  public string PhoneNumber { get; set; }
}