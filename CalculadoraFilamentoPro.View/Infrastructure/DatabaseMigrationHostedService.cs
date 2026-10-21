using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Infrastructure;

public sealed class DatabaseMigrationHostedService
{
    private readonly IConfigurationRepository _configurationRepository;
    private readonly IServiceScopeFactory _scopeFactory;

    public DatabaseMigrationHostedService(
        IConfigurationRepository configurationRepository,
        IServiceScopeFactory scopeFactory)
    {
        _configurationRepository = configurationRepository;
        _scopeFactory = scopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var configuration = await _configurationRepository.GetConfigurationAsync();

            if (configuration.Database is null)
                return;

            await using var scope = _scopeFactory.CreateAsyncScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDataBaseInitializer>();

            await initializer.InitializeDatabaseAsync();
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
                }
        
    }

}
