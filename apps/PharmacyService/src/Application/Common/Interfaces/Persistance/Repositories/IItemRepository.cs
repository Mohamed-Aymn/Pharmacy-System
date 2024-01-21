using Application.Common.Interfaces.Persistance;
using OrderService.Domain.Item.Entites;

namespace OrderService.Application.Common.Interfaces.Persistence.Respositories;

public interface IItemRepository : IRepository<Item, Guid>
{
}