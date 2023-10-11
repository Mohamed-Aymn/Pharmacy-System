using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Domain.Address.Entities;

namespace OrderService.Infrastructure.Persistence;

public class AddressRepository : IAddressRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public AddressRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Address entity)
    {
        await _dbContext.Address.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity! != null!)
        {
            _dbContext.Address.Remove(entity);
        }
    }

    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        return await _dbContext.Address.ToListAsync();
    }

    public async Task<Address?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Address.FindAsync(id);
    }

    public async Task UpdateAsync(Address entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id.Value);
        if (existingEntity! != null!)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}