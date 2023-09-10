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
    public async Task<IActionResult> UpdateUser(ObjectId id, User user)
    {
        await _mongoDBService.UpdateAsync(id, user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(ObjectId id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}