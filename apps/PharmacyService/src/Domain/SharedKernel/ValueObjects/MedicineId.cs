namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class MedicineId : ValueObject
{
  public MedicineId(string value)
  {
    Value = value;
  }
  public MedicineId(string name, string concentration)
  {
    Value = $"{name} {concentration}";
  }

  public string Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}