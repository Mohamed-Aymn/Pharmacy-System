using AuthenticationService.ApiValidation;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using AuthenticationService.Utilities;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    private readonly MongoDBService _mongoDBService;

    private readonly IConfiguration _config;
    public AuthenticationController(MongoDBService mongoDBService, IConfiguration config)
    {
        _mongoDBService = mongoDBService;
        _config = config;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(User user)
    {
        // body validation
        UserValidator validator = new();
        FluentValidation.Results.ValidationResult results = validator.Validate(user);
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

        // hash password
        user.Password = PasswordHasher.HashPassword(user.Password!);

        // store user in database (create user)
        await _mongoDBService.CreateAsync(user);

        // generate jwt
        var token = GenerateToken(user);

        // store jwt in cookies
        CookieOptions cookieOptions = new()
        {
            Expires = DateTime.Now.AddDays(1),
            Path = "/",
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("Token", token, cookieOptions);

        return Ok();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(string email, string password)
    {
        // body validation
        // UserValidator validator = new();
        // FluentValidation.Results.ValidationResult results = validator.Validate(user);
        // if (!results.IsValid)
        // {
        // foreach (var failure in results.Errors)
        // {
        // }
        //     throw new Exception();
        // }

        // check if email exists
        var userData = await _mongoDBService.GetByEmail(email)
            ?? throw new Exception("something went wrong");

        // check if valid password
        var test = PasswordHasher.ValidatePassword(password, userData.Password!);
        if (!PasswordHasher.ValidatePassword(password, userData.Password!))
        {
            throw new Exception("something went wrong");
        }

        // generate jwt
        var token = GenerateToken(userData);

        // store jwt in cookies
        CookieOptions cookieOptions = new()
        {
            Expires = DateTime.Now.AddDays(1),
            Path = "/",
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("Token", token, cookieOptions);

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

    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // token payload
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Name!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
        };

        var token = new JwtSecurityToken
        (
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}