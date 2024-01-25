namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class CashierId : ValueObject
{
  public CashierId(Guid value)
  {
    Value = value;
  }
  public CashierId()
  {
    Value = Guid.NewGuid();
  }

  public Guid Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
