namespace PharmacyService.Domain.SharedKernel.ValueObjects;

public class MedicineId : ValueObject
{
  public MedicineId(Guid id)
  {
    Id = id;
  }
  public MedicineId()
  {
    Id = Guid.NewGuid();
  }


  public Guid Id { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}
