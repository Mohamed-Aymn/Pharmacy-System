namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class MedicineId : ValueObject
{
  public MedicineId(Guid value)
  {
    Value = value;
  }
  public MedicineId()
  {
    Value = Guid.NewGuid();
  }

  public Guid Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
