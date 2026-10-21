using CalculadoraFilamentoPro.App.User.Interfaces;
using CalculadoraFilamentoPro.App.Users.Security;
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

    public async Task CreateUser(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha deve possuir pelo menos 8 caracteres.", nameof(password));

        if (await _userRepository.FindByUserNameAsync(userName) is not null)
            throw new InvalidOperationException("Já existe um usuário com esse nome.");

        var user = new CalculadoraFilamentoPro.Domain.Users.Entities.User(userName, PasswordHasher.Hash(password));

        await _userRepository.AddAsync(user);
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        if (configuration.LastUserId is null)
            return false;

        var user = await _userRepository.GetByIdAsync(configuration.LastUserId.Value);

        return user is not null && user.SessionActive;
    }
}