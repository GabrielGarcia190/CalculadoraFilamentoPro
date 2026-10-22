using CalculadoraFilamentoPro.App.Interfaces.Authentication;
using CalculadoraFilamentoPro.Domain.Authentication.Results;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Users.Repositories;
using CalculadoraFilamentoPro.App.Users.Security;

namespace CalculadoraFilamentoPro.App.Configurations.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    private readonly IConfigurationRepository _configurationRepository;

    public AuthenticationService(IUserRepository userRepository, IConfigurationRepository configurationRepository)
    {
        _userRepository = userRepository;
        _configurationRepository = configurationRepository;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        if (configuration.LastUserId is null) return false;

        var user = await _userRepository.GetByIdAsync(configuration.LastUserId.Value);

        return user is not null && user.SessionActive;
    }

    public async Task<LoginResult> LoginAsync(string userName, string password)
    {
        try
        {
            var user = await _userRepository.FindByUserNameAsync(userName);

            if (user is null || !PasswordHasher.Verify(password, user.PasswordHash))
                return new LoginResult { Error = "Nome de usuário ou senha inválidos." };

            user.Login();

            await _userRepository.SaveAsync(user);

            var configuration = await _configurationRepository.GetConfigurationAsync();

            configuration.Login(user.Id, true);

            await _configurationRepository.SaveConfigurationAsync(configuration);

            return new LoginResult { Success = true, User = user };
        }
        catch (Exception ex)
        {
            return new LoginResult { Error = ex.Message };
        }
    }

    public async Task LogoutAsync()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        configuration.Logout();

        await _configurationRepository.SaveConfigurationAsync(configuration);
    }
}
