namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class PharmacistId : ValueObject
{
  public PharmacistId(Guid value)
  {
    Value = value;
  }
  public PharmacistId()
  {
    Value = Guid.NewGuid();
  }

  public Guid Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
