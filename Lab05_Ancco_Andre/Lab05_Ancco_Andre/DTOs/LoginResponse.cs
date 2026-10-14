namespace Lab05_Ancco_Andre.DTOs;

public class LoginResponse
{
    public bool Success { get; set; }
    public string Token { get; set; } = null!;
}