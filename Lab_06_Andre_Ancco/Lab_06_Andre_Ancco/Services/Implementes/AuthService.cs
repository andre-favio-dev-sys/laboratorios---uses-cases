using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab_06_Andre_Ancco.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Lab_06_Andre_Ancco.Services.Implementes;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Login(LoginModel login)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.UserName),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim("CanViewUsers", "true"),
            new Claim("CanEditUsers", "true")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:SecretKey"]!
            )
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}