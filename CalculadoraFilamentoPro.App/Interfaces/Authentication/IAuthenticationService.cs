using CalculadoraFilamentoPro.Domain.Authentication.Results;

namespace CalculadoraFilamentoPro.App.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<LoginResult> LoginAsync(string email);

    Task LogoutAsync();

    Task<bool> IsAuthenticatedAsync();
}