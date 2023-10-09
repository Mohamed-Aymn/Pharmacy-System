using Application.Common.Interfaces.Persistance;
using OrderService.Domain.Address.Entities;

namespace OrderService.Application.Common.Interfaces.Persistence.Respositories;

public interface IAddressRepository : IRepository<Address, Guid>
{
}