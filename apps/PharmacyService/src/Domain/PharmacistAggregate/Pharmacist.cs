using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.PharmacistAggregate;

public class Pharmacist : AggregateRoot<PharmacistId>
{
  public Pharmacist(PharmacistId id) : base(id) { }

  public string Name { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }
  public PharmacistRole Role { get; set; }
}