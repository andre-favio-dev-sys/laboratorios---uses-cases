using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab05_Ancco_Andre.DTOs;
using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Lab05_Ancco_Andre.Services.Implements;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    private readonly PasswordHasher<User> _passwordHasher = new();

    public AuthService(
        IUnitOfWork unitOfWork,
        IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<User> RegisterAsync(RegisterModel model)
    {
        var usuarios = await _unitOfWork
            .Repository<User>()
            .GetAllAsync();

        if (usuarios.Any(u => u.UserName == model.Username))
        {
            throw new InvalidOperationException(
                "El nombre de usuario ya existe.");
        }

        var usuario = new User
        {
            UserName = model.Username,
            Role = model.Rol
        };

        usuario.PasswordHash =
            _passwordHasher.HashPassword(
                usuario,
                model.Password);

        await _unitOfWork
            .Repository<User>()
            .InsertAsync(usuario);

        await _unitOfWork.Complete();

        return usuario;
    }

    public async Task<LoginResponse> LoginAsync(LoginModel model)
    {
        var usuarios = await _unitOfWork
            .Repository<User>()
            .GetAllAsync();

        var usuario = usuarios.FirstOrDefault(
            u => u.UserName == model.Username);

        if (usuario == null)
        {
            throw new UnauthorizedAccessException(
                "Usuario o contraseña incorrectos.");
        }

        var resultado =
            _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.PasswordHash,
                model.Password);

        if (resultado == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException(
                "Usuario o contraseña incorrectos.");
        }

        var token = GenerarToken(usuario);

        return new LoginResponse
        {
            Success = true,
            Token = token
        };
    }

    private string GenerarToken(User usuario)
    {
        var claims = new[]
        {
            new Claim(
                ClaimTypes.Name,
                usuario.UserName),

            new Claim(
                ClaimTypes.Role,
                usuario.Role),

            new Claim(
                "CanViewUsers",
                "true")
        };

        var secretKey =
            _configuration["Jwt:SecretKey"]
            ?? throw new InvalidOperationException(
                "Jwt:SecretKey no está configurado.");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}