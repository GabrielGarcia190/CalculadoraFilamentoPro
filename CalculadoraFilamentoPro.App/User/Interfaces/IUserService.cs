namespace CalculadoraFilamentoPro.App.User.Interfaces;

public interface IUserService
{
    Task<bool> IsUserAuthenticated();
    Task CreateUser(string userName, string password);
}