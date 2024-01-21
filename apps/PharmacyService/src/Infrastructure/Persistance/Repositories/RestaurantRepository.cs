using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Domain.Restaurant.Entites;

namespace OrderService.Infrastructure.Persistence;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public RestaurantRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Restaurant entity)
    {
        await _dbContext.Restaurant.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity! != null!)
        {
            _dbContext.Restaurant.Remove(entity);
        }
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        return await _dbContext.Restaurant.ToListAsync();
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Restaurant.FindAsync(id);
    }

    public async Task UpdateAsync(Restaurant entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id.Value);
        if (existingEntity! != null!)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}