using CalculadoraFilamentoPro.App.Users.Interfaces;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Users.Repositories;
using CalculadoraFilamentoPro.App.Users.Security;

namespace CalculadoraFilamentoPro.App.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfigurationRepository _configurationRepository;

    public UserService(IUserRepository userRepository, IConfigurationRepository configurationRepository)
    {
        _userRepository = userRepository;
        _configurationRepository = configurationRepository;
    }

    public async Task CreateUser(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha deve possuir pelo menos 8 caracteres.", nameof(password));

        if (await _userRepository.FindByUserNameAsync(email) is not null)
            throw new InvalidOperationException("Já existe um usuário com esse nome.");

        var passwordHash = PasswordHasher.Hash(password);
        var user = new CalculadoraFilamentoPro.Domain.Users.Entities.User(email, passwordHash);

        await _userRepository.AddAsync(user);
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        if (configuration.LastUserId is null) return false;

        var user = await _userRepository.GetByIdAsync(configuration.LastUserId ?? Guid.Empty);

        return user is not null;
    }
}
