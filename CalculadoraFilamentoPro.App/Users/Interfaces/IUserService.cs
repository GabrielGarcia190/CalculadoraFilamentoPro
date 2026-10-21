namespace CalculadoraFilamentoPro.App.Users.Interfaces;

public interface IUserService
{
    Task<bool> IsUserAuthenticated();

    Task CreateUser(string email, string password);
}