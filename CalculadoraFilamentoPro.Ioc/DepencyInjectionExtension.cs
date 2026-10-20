using CalculadoraFilamentoPro.Ioc.Application;
using CalculadoraFilamentoPro.Ioc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.Ioc;

public static class DepencyInjectionExtension
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        ApplicationConfig.Register(services);
        InfrastructureConfig.Register(services);
    }
}