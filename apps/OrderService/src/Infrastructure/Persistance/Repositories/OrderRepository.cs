using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Domain.Order.Entites;

namespace OrderService.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public OrderRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Order entity)
    {
        await _dbContext.Order.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity! != null!)
        {
            _dbContext.Order.Remove(entity);
        }
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbContext.Order.ToListAsync();
    }

    public async Task<Order?> GetByEmailAsync(string email)
    {
        return await _dbContext.Order.FindAsync(email);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Order.FindAsync(id);
    }

    public async Task UpdateAsync(Order entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id.Value);
        if (existingEntity! != null!)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}