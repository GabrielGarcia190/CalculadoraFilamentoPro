namespace CalculadoraFilamentoPro.App.Interfaces.Configurations
{
    public interface IConfigurationService
    {
        Task<bool> DatabaseConfiguredAsync();

        Task ConfigureDataBase(string connectionString);
    }
}