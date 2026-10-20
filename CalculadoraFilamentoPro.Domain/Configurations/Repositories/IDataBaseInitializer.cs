namespace CalculadoraFilamentoPro.Domain.Configurations.Repositories;

public interface IDataBaseInitializer
{
    Task InitializeDatabaseAsync();
}
