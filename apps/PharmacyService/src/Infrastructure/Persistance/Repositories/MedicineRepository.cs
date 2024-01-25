using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Common.Interfaces.Persistence.Respositories;
using PharmacyService.Domain.MedicineAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Infrastructure.Persistence;

public class MedicineRepository : IMedicineRepository<Medicine, MedicineId>
{
  private readonly PharmacyServiceDbContext _dbContext;

  public MedicineRepository(PharmacyServiceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Medicine entity)
  {
    await _dbContext.Medicines.AddAsync(entity);
  }

  public async Task DeleteAsync(Guid id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Medicines.Remove(entity);
    }
  }

  public async Task DeleteAsync(MedicineId id)
  {
    var entity = await GetByIdAsync(id);
    if (entity! != null!)
    {
      _dbContext.Medicines.Remove(entity);
    }
  }

  public async Task<IEnumerable<Medicine>> GetAllAsync()
  {
    return await _dbContext.Medicines.ToListAsync();
  }

  public async Task<Medicine?> GetByEmailAsync(string email)
  {
    return await _dbContext.Medicines.FindAsync(email);
  }

  public async Task<Medicine?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Medicines.FindAsync(id);
  }

  public async Task<Medicine?> GetByIdAsync(MedicineId id)
  {
    return await GetByIdAsync(id.Value);
  }

  public async Task UpdateAsync(Medicine entity)
  {
    var existingEntity = await GetByIdAsync(entity.Id.Value);
    if (existingEntity! != null!)
    {
      _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
  }
}