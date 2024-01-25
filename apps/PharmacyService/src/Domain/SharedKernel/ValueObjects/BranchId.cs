namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class BranchId : ValueObject
{
  public BranchId(Guid value)
  {
    Value = value;
  }
  public BranchId()
  {
    Value = Guid.NewGuid();
  }


  public Guid Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
