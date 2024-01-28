using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Infrastructure.Persistence;

public class PharmacistRepository : IPharmacistRepository<Pharmacist, PharmacistId>
{
  private readonly PharmacyServiceDbContext _dbContext;

  public PharmacistRepository(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Pharmacist entity)
  {
    await _dbContext.Pharmacists.AddAsync(entity);
  }

  public async Task DeleteAsync(PharmacistId id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Pharmacists.Remove(entity);
    }
  }

  public async Task<IEnumerable<Pharmacist>> GetAllAsync()
  {
    return await _dbContext.Pharmacists.ToListAsync();
  }

  public async Task<Pharmacist?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Pharmacists.FindAsync(id);
  }

  public async Task<Pharmacist?> GetByIdAsync(PharmacistId id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Pharmacists.Remove(entity);
    }
    return entity;
  }

  public async Task UpdateAsync(Pharmacist entity)
  {
    var existingEntity = await GetByIdAsync(entity.Id.Value);
    if (existingEntity! != null!)
    {
      _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
  }
}