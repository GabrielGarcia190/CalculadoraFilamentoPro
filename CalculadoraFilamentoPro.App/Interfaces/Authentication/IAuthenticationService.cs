using CalculadoraFilamentoPro.Domain.Authentication.Results;

namespace CalculadoraFilamentoPro.App.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<LoginResult> LoginAsync(string email, string password);

    Task LogoutAsync();

    Task<bool> IsAuthenticatedAsync();
}