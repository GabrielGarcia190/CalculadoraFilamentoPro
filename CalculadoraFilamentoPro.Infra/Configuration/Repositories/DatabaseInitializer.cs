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
        var options = _factory.CreateOptions();

        await using var context = new AppDbContext(options);

        await context.Database.MigrateAsync();
    }
}
