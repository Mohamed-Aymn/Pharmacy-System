using AuthenticationService.ApiValidation;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using AuthenticationService.Services;
using Microsoft.Extensions.Logging;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public AuthenticationController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(User user)
    {
        // body validation
        UserValidator validator = new();
        ValidationResult results = validator.Validate(user);
        if (!results.IsValid)
        {
            // foreach (var failure in results.Errors)
            // {
            // }
            throw new Exception();
        }

        // check if email exists
        var duplicateEmailCheck = await _mongoDBService.GetByEmail(user.Email!);
        if (duplicateEmailCheck != null)
        {
            throw new Exception("something went wrong");
        }

        // create user
        await _mongoDBService.CreateAsync(user);

        // generate jwt

        // store jwt in cookies

        return Ok();
    }

    [HttpPost("signin")]
    public IActionResult Signin(User user)
    {
        // body validation
        UserValidator validator = new();
        ValidationResult results = validator.Validate(user);
        if (!results.IsValid)
        {
            // foreach (var failure in results.Errors)
            // {
            // }
            throw new Exception();
        }

        // check if email exists

        // check if valid password

        // generate jwt

        // store jwt in cookies

        return Ok();
    }

    [HttpPost("signout")]
    public IActionResult Signout()
    {
        // delete jwt from session
        return Ok();
    }

    [HttpGet("currentuser")]
    public IActionResult CurrentUser()
    {
        // return current user or null
        return Ok();
    }
}