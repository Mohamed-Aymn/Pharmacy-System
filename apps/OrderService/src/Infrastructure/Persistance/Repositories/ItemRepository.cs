using Application.Common.Interfaces.Persistance;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Domain.Item.Entites;

namespace OrderService.Infrastructure.Persistence;

public class ItemRepository : IItemRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public ItemRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Item entity)
    {
        await _dbContext.Item.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity! != null!)
        {
            _dbContext.Item.Remove(entity);
        }
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _dbContext.Item.ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Item.FindAsync(id);
    }

    public async Task UpdateAsync(Item entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id.Value);
        if (existingEntity! != null!)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}