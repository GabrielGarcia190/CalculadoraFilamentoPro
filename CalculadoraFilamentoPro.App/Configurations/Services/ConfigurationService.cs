using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.App.Configurations.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationService(IConfigurationRepository configurationRepository)
        => _configurationRepository = configurationRepository;

    public async Task ConfigureDataBase(string connectionString)
    {
        var configu = new DataBaseConnection(EDatabaseProvider.SQLite, connectionString);

        await _configurationRepository.SaveConnectionStringAsync(configu);
    }

    public async Task<bool> DatabaseConfiguredAsync()
    {
        var connectionString = await _configurationRepository.GetConnectionStringAsync();

        return connectionString != null;
    }
}