using AuthenticationService.Validators;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using AuthenticationService.Utilities;
using Microsoft.AspNetCore.Authorization;
using AuthenticationService.Contracts;
using AuthenticationService.Presistence;
using FluentValidation.Results;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Signup(RegisterUserRequest request)
    {
        // body validation
        RegisterUserValidator validator = new();
        ValidationResult results = validator.Validate(request);
        if (!results.IsValid)
        {
            throw new Exception("something went wrong");
        }

        // check if email exists
        var duplicateEmailCheck = await _userRepository.GetByEmail(request.Email!);
        if (duplicateEmailCheck != null)
        {
            throw new Exception("something went wrong");
        }

        // hash password
        request.Password = PasswordHasher.HashPassword(request.Password!);

        // store user in database (create user)
        User user = new(
            name: request.Name,
            email: request.Email,
            password: request.Password
        );
        await _userRepository.Add(user);

        // generate jwt
        var token = TokenGenerator.GenerateToken(user);

        // store jwt in cookies
        CookieOptions cookieOptions = new()
        {
            Expires = DateTime.Now.AddDays(1),
            Path = "/",
            HttpOnly = true,
        };
        Response.Cookies.Append("Token", token, cookieOptions);

        return Ok("User created successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Signin(SigninRequest request)
    {
        // body validation
        SigninValidator validator = new();
        FluentValidation.Results.ValidationResult results = validator.Validate(request);
        if (!results.IsValid)
        {
            throw new Exception("something went wrong");
        }

        // check if email exists
        var userData = await _userRepository.GetByEmail(request.Email)
            ?? throw new Exception("something went wrong");

        // check if valid password
        if (!PasswordHasher.ValidatePassword(request.Password, userData.Password!))
        {
            throw new Exception("something went wrong");
        }

        // generate jwt
        var token = TokenGenerator.GenerateToken(userData);

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
}