using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.MedicineAggregate;
using PharmacyService.Domain.ReceiptAggregate;

namespace PharmacyService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
  IBranchRepository<Branch, BranchId> Branches { get; }
  IPharmacistRepository<Pharmacist, PharmacistId> Pharmacists { get; }
  ICashierRepository<Cashier, CashierId> Cashiers { get; }
  IMedicineRepository<Medicine, MedicineId> Medicines { get; }
  IReceiptRepository<Receipt, ReceiptId> Receipts { get; }
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}