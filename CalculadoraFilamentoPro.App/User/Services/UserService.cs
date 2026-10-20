using CalculadoraFilamentoPro.App.User.Interfaces;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Users.Repositories;

namespace CalculadoraFilamentoPro.App.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfigurationRepository _configurationRepository;

    public UserService(IUserRepository userRepository, IConfigurationRepository configurationRepository)
    {
        _userRepository = userRepository;
        _configurationRepository = configurationRepository;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        if (configuration.LastUserId is null) return false;

        var user = await _userRepository.GetByIdAsync(configuration.LastUserId ?? Guid.Empty);

        return user is not null;
    }
}
