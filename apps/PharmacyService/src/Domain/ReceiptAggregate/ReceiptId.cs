using PharmacyService.Domain.SharedKernel;

namespace PharmacyService.Domain.ReceiptAggregate;

public class ReceiptId : ValueObject
{
  public ReceiptId(Guid value)
  {
    Value = value;
  }
  public ReceiptId()
  {
    Value = Guid.NewGuid();
  }


  public Guid Value { get; set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
