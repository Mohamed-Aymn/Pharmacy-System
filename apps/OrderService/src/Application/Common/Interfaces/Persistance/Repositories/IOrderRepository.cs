using Application.Common.Interfaces.Persistance;
using Namespace = OrderService.Domain.Order.Entites;

namespace OrderService.Application.Common.Interfaces.Persistence.Respositories;

public interface IOrderRepository : IRepository<Namespace.Order, Guid>
{
    Task<Namespace.Order?> GetByEmailAsync(string email);
}