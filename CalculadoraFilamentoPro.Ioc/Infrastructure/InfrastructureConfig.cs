using CalculadoraFilamentoPro.Domain.Configurations.Entities;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Users.Repositories;
using CalculadoraFilamentoPro.Infra.Configuration.Repositories;
using CalculadoraFilamentoPro.Infra.Shared.Persistence;
using CalculadoraFilamentoPro.Infra.Users;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Ioc.Infrastructure;

internal static class InfrastructureConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
        services.AddSingleton<ApplicationConfiguration>(provider =>
        {
            var repository = provider.GetRequiredService<IConfigurationRepository>();

            repository.Load();

            return repository.Configuration;
        });
        services.AddTransient<AppDbContextFactory>();
        services.AddScoped<AppDbContext>(provider =>
        {
            var factory = provider.GetRequiredService<AppDbContextFactory>();

            var options = factory.CreateOptions();

            return new AppDbContext(options);
        });
        services.AddScoped<IDataBaseInitializer, DatabaseInitializer>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}