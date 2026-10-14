using Lab_06_Andre_Ancco.DTOs;

namespace Lab_06_Andre_Ancco.Services;

public interface IAuthService
{
    string Login(LoginModel login);
}