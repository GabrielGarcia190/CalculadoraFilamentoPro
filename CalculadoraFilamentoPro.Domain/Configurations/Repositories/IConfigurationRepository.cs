using CalculadoraFilamentoPro.Domain.Configurations. Entities;

namespace CalculadoraFilamentoPro.Domain.Configurations.Repositories;

public interface IConfigurationRepository
{
    ApplicationConfiguration Configuration { get; }

    Task<ApplicationConfiguration> GetConfigurationAsync();

    Task SaveConfigurationAsync(ApplicationConfiguration configuration);

    void Load();
}