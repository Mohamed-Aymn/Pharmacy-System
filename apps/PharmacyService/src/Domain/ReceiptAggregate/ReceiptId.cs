using PharmacyService.Domain.SharedKernel;

namespace PharmacyService.Domain.ReceiptAggregate;

public class ReceiptId : ValueObject
{
  public ReceiptId(Guid id)
  {
    Id = id;
  }
  public ReceiptId()
  {
    Id = Guid.NewGuid();
  }


  public Guid Id { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}
