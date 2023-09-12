using AuthenticationService.Validators;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using AuthenticationService.Utilities;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Services;
using System.ComponentModel.DataAnnotations;

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

    [HttpPost("register")]
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
        };
        Response.Cookies.Append("Token", token, cookieOptions);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Signin(User user)
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
        var userData = await _mongoDBService.GetByEmail(user.Email)
            ?? throw new Exception("something went wrong");

        // check if valid password
        if (!PasswordHasher.ValidatePassword(user.Password, userData.Password!))
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

    [Authorize]
    [HttpPost("logout")]
    public IActionResult Signout()
    {
        Response.Cookies.Delete("Token", new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.None,
            Secure = true
        });
        return Ok();
    }

    [Authorize]
    [HttpGet("currentuser")]
    public IActionResult CurrentUser()
    {
        // get token from cookie
        string token = Request.Cookies["Token"]! ?? throw new Exception("something went wrong");

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedToken = tokenHandler.ReadJwtToken(token);

        string userId = decodedToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value!;
        string userName = decodedToken.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value!;
        string userEmail = decodedToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value!;

        // return current user or null
        return Ok(new
        {
            currentUser = new
            {
                id = userId,
                name = userName,
                email = userEmail
            }
        });
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