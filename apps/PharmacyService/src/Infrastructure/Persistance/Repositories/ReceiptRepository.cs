using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.ReceiptAggregate;

namespace PharmacyService.Infrastructure.Persistence;

public class ReceiptRepository : IReceiptRepository<Receipt, ReceiptId>
{
  private readonly PharmacyServiceDbContext _dbContext;

  public ReceiptRepository(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Receipt entity)
  {
    await _dbContext.Receipts.AddAsync(entity);
  }

  public async Task DeleteAsync(ReceiptId id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Receipts.Remove(entity);
    }
  }

  public async Task<IEnumerable<Receipt>> GetAllAsync()
  {
    return await _dbContext.Receipts.ToListAsync();
  }
  public async Task<Receipt?> GetByIdAsync(ReceiptId id)
  {
    return await GetByIdAsync(id);
  }

  public async Task UpdateAsync(Receipt entity)
  {
    var existingEntity = await GetByIdAsync(entity.Id);
    if (existingEntity! != null!)
    {
      _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
  }
}