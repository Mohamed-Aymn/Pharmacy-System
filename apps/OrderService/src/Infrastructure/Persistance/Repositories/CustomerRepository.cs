using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Interfaces.Persistence.Respositories;
using OrderService.Domain.Customer.Entites;

namespace OrderService.Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
    private readonly OrderServiceDbContext _dbContext;
    public CustomerRepository(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Customer entity)
    {
        await _dbContext.Customer.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity! != null!)
        {
            _dbContext.Customer.Remove(entity);
        }
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _dbContext.Customer.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Customer.FindAsync(id);
    }

    public async Task UpdateAsync(Customer entity)
    {
        var existingEntity = await GetByIdAsync(entity.Id.Value);
        if (existingEntity! != null!)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}