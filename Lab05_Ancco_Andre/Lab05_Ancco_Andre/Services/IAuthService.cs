using Lab05_Ancco_Andre.DTOs;
using Lab05_Ancco_Andre.Models;

namespace Lab05_Ancco_Andre.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterModel model);
    Task<LoginResponse> LoginAsync(LoginModel model);
}