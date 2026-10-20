using CalculadoraFilamentoPro.Domain.Users.Entities;

namespace CalculadoraFilamentoPro.Domain.Authentication.Results;

public class LoginResult
{
    public bool Success { get; set; }

    public string? Error { get; set; }

    public User? User { get; set; }
}