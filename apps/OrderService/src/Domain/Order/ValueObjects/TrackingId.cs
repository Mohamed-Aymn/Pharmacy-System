using OrderService.Domain.Common.Models;

public class TrackingId : ValueObject
{
    public Guid Id { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
