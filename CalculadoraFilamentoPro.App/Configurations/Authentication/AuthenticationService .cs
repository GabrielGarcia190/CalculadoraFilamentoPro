using CalculadoraFilamentoPro.App.Interfaces.Authentication;
using CalculadoraFilamentoPro.Domain.Authentication.Results;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Users.Repositories;

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

    public async Task<LoginResult> LoginAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);

        if (user is null)
            return new LoginResult { Error = "Usuário não encontrado." };

        user.Login();

        await _userRepository.SaveAsync(user);

        var configuration = await _configurationRepository.GetConfigurationAsync();

        configuration.Login(user.Id, true);

        await _configurationRepository.SaveConfigurationAsync(configuration);

        return new LoginResult { User = user };
    }

    public async Task LogoutAsync()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        configuration.Logout();

        await _configurationRepository.SaveConfigurationAsync(configuration);
    }
}
