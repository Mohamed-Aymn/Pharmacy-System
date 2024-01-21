using Application.Common.Interfaces.Persistance;
using OrderService.Domain.Restaurant.Entites;

namespace OrderService.Application.Common.Interfaces.Persistence.Respositories;

public interface IRestaurantRepository : IRepository<Restaurant, Guid>
{
}