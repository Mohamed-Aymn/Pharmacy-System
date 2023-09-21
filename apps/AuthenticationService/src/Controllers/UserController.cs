using AuthenticationService.Contracts;
using AuthenticationService.Models;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AuthenticationService.Controllers;

[Route("api/users")]
public class UserController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public UserController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, RegisterUserRequest request)
    {
        User user = new(
            name: request.Name,
            email: request.Email,
            password: request.Password
        );
        await _mongoDBService.UpdateAsync(id, user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}