using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.App.Configurations.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;
    private readonly IDataBaseInitializer _dataBaseInitializer;

    public ConfigurationService(IConfigurationRepository configurationRepository, IDataBaseInitializer dataBaseInitializer)
    {
        _configurationRepository = configurationRepository;
        _dataBaseInitializer = dataBaseInitializer;
    }

    public async Task ConfigureDataBase(DataBaseConnection configureDataBase)
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        configuration.ConfigureDatabase(configureDataBase);

        await _configurationRepository.SaveConfigurationAsync(configuration);
        await _dataBaseInitializer.InitializeDatabaseAsync();
    }

    public async Task<bool> DatabaseConfiguredAsync()
    {
        var configuration = await _configurationRepository.GetConfigurationAsync();

        return configuration?.Database != null;
    }
}