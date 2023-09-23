using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationService.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Utilities;

public static class TokenGenerator
{
    public static string GenerateToken(User user)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:Key")!));
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
            issuer: config.GetValue<string>("Jwt:Issuer"),
            audience: config.GetValue<string>("Jwt:Audience"),
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}