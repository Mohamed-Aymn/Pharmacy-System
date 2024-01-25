using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;
using PharmacyService.Infrastructure.Persistence;

namespace OrderService.Infrastructure.Persistence;
public class BranchRepository : IBranchRepository<Branch, BranchId>
{
  private readonly PharmacyServiceDbContext _dbContext;
  public BranchRepository(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Branch entity)
  {

    await _dbContext.Branches.AddAsync(entity);
  }

  public async Task DeleteAsync(BranchId id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Branches.Remove(entity);
    }
  }

  public async Task<IEnumerable<Branch>> GetAllAsync()
  {
    return await _dbContext.Branches.ToListAsync();
  }

  public async Task<Branch?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Branches.FindAsync(id);
  }

  public Task<Branch?> GetByIdAsync(BranchId id)
  {
    throw new NotImplementedException();
  }

  public async Task UpdateAsync(Branch entity)
  {
    var existingEntity = await GetByIdAsync(entity.Id.Value);
    if (existingEntity! != null!)
    {
      _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
  }
}