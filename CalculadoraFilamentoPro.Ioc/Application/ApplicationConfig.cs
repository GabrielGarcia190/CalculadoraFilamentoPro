using CalculadoraFilamentoPro.App.Configurations.Services;
using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddSingleton<IConfigurationService, ConfigurationService>();
    }
}