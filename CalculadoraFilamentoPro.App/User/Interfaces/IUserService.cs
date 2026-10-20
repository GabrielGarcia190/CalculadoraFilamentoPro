namespace CalculadoraFilamentoPro.App.User.Interfaces;

public interface IUserService
{
    Task<bool> IsUserAuthenticated();
}