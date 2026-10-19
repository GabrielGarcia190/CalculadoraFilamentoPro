using CalculadoraFilamentoPro.App.Interfaces.Configurations;

namespace CalculadoraFilamentoPro.App.Configurations.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public Task ConfigureDataBase(string connectionString)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DatabaseConfiguredAsync()
        {
            throw new NotImplementedException();
        }
    }
}
