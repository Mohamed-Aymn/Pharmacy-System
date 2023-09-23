using AuthenticationService.Models;

namespace AuthenticationService.Presistence;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}