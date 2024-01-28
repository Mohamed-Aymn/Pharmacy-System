using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Infrastructure.Persistence;

public class CashierRepository : ICashierRepository<Cashier, CashierId>
{
  private readonly PharmacyServiceDbContext _dbContext;

  public CashierRepository(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Cashier entity)
  {
    await _dbContext.Cashiers.AddAsync(entity);
  }

  public async Task DeleteAsync(Guid id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Cashiers.Remove(entity);
    }
  }

  public Task DeleteAsync(CashierId id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Cashier>> GetAllAsync()
  {
    return await _dbContext.Cashiers.ToListAsync();
  }

  public async Task<Cashier?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Cashiers.FindAsync(id);
  }

  public Task<Cashier?> GetByIdAsync(CashierId id)
  {
    throw new NotImplementedException();
  }

  public async Task UpdateAsync(Cashier entity)
  {
    var existingEntity = await GetByIdAsync(entity.Id.Value);
    if (existingEntity! != null!)
    {
      _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
  }
}