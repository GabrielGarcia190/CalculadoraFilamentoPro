using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Infra.Shared.Persistence;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Infra.Configuration.Repositories;

public class DatabaseInitializer : IDataBaseInitializer
{
    private readonly AppDbContextFactory _factory;

    public DatabaseInitializer(AppDbContextFactory factory)
        => _factory = factory;

    public async Task InitializeDatabaseAsync()
    {
        try
        {
            var options = _factory.CreateOptions();

            using var context = new AppDbContext(options);

            await context.Database.MigrateAsync();
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
}
