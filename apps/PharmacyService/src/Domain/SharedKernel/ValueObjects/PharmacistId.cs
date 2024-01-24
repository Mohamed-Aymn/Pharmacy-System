namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class PharmacistId : ValueObject
{
  public PharmacistId(Guid id)
  {
    Id = id;
  }
  public PharmacistId()
  {
    Id = Guid.NewGuid();
  }

  public Guid Id { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}
