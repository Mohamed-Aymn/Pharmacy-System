using AuthenticationService.ApiValidation;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using MongoDB.Driver.Core.Authentication;

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
        byte[] salt = GenerateSalt();
        user.Password = Encrypt(user.Password!, salt);

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
    public IActionResult Signin(User user)
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

        // check if valid password
        // bool isValid = ValidatePassword(user.Password, encryptedPassword);

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

    private static string Encrypt(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20); // 20 bytes = 160 bits (SHA-1)
        byte[] hashBytes = new byte[36]; // 36 bytes = 288 bits (160 + 128)
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        string encryptedPassword = Convert.ToBase64String(hashBytes);
        return encryptedPassword;
    }

    private static bool ValidatePassword(string enteredPassword, string storedEncryptedPassword)
    {
        byte[] hashBytes = Convert.FromBase64String(storedEncryptedPassword);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        string enteredEncryptedPassword = Encrypt(enteredPassword, salt);
        return storedEncryptedPassword.Equals(enteredEncryptedPassword);
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16]; // 16 bytes = 128 bits
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }
}