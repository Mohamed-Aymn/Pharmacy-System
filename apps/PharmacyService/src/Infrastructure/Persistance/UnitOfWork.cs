using OrderService.Infrastructure.Persistence;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.MedicineAggregate;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.ReceiptAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;
using PharmacyService.Infrastructure.Persistence;

namespace PharmacyService.Infrastructure;
internal sealed class UnitOfWork : IUnitOfWork
{
  private readonly PharmacyServiceDbContext _dbContext;
  public UnitOfWork(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
    Branches = new BranchRepository(_dbContext);
    Pharmacists = new PharmacistRepository(_dbContext);
    Cashiers = new CashierRepository(_dbContext);
    Medicines = new MedicineRepository(_dbContext);
    Receipts = new ReceiptRepository(_dbContext);
  }

  public IBranchRepository<Branch, BranchId> Branches { get; private set; }
  public IPharmacistRepository<Pharmacist, PharmacistId> Pharmacists { get; private set; }

  public ICashierRepository<Cashier, CashierId> Cashiers { get; private set; }

  public IMedicineRepository<Medicine, MedicineId> Medicines { get; private set; }

  public IReceiptRepository<Receipt, ReceiptId> Receipts { get; private set; }

  public void Dispose()
  {
    _dbContext.Dispose();
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _dbContext.SaveChangesAsync(cancellationToken);
  }
}