using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.App.Interfaces.Configurations;

public interface IConfigurationService
{
    Task<bool> DatabaseConfiguredAsync();

    Task ConfigureDataBase(DataBaseConnection connectionString);
}