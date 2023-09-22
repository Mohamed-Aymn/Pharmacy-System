using AuthenticationService.Contracts;
using AuthenticationService.Models;
using AuthenticationService.Presistence;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers;

[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, RegisterUserRequest request)
    {
        User user = new(
            name: request.Name,
            email: request.Email,
            password: request.Password
        );
        await _userRepository.UpdateAsync(id, user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _userRepository.DeleteAsync(id);
        return NoContent();
    }

}