using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Infra.Configuration.Repositories;
using CalculadoraFilamentoPro.Infra.Shared.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Ioc.Infrastructure;

internal static class InfrastructureConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
        //services.AddSingleton<AppDbContextFactory>();
    }
}