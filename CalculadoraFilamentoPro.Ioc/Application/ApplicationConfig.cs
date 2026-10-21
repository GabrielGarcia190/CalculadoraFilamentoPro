using CalculadoraFilamentoPro.App.Configurations.Authentication;
using CalculadoraFilamentoPro.App.Configurations.Services;
using CalculadoraFilamentoPro.App.Interfaces.Authentication;
using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using CalculadoraFilamentoPro.App.User.Interfaces;
using CalculadoraFilamentoPro.App.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Ioc.Application;

internal static class ApplicationConfig
{
    internal static void Register(IServiceCollection services)
    {
        services.AddSingleton<IConfigurationService, ConfigurationService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
    }
}