using Application.Common.Interfaces.Persistance;
using OrderService.Domain.Customer.Entites;

namespace OrderService.Application.Common.Interfaces.Persistence.Respositories;

public interface ICustomerRepository : IRepository<Customer, Guid>
{
}