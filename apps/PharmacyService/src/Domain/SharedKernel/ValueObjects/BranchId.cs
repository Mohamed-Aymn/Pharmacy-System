namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class BranchId : ValueObject
{
  public BranchId(Guid id)
  {
    Id = id;
  }
  public BranchId()
  {
    Id = Guid.NewGuid();
  }


  public Guid Id { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}
