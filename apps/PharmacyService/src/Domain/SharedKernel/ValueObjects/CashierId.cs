namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class CashierId : ValueObject
{
  public CashierId(Guid id)
  {
    Id = id;
  }
  public CashierId()
  {
    Id = Guid.NewGuid();
  }

  public Guid Id { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}
