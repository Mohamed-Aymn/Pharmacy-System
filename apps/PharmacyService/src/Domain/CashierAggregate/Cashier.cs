using PharmacyService.Domain.SharedKernel;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Domain.CashierAggregate;

public class Cashier : AggregateRoot<CashierId>
{
  public Cashier(CashierId id) : base(id) { }

  public string Name { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }
}