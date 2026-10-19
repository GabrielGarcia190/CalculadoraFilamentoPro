using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.Domain.Configurations.Repositories;

public interface IConfigurationRepository
{
    Task SaveConnectionStringAsync(DataBaseConnection connectionString);

    Task<DataBaseConnection?> GetConnectionStringAsync();
}