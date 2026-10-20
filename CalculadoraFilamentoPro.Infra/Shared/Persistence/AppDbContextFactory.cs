using CalculadoraFilamentoPro.Domain.Configurations.Entities;
using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Infra.Shared.Persistence
{
    public class AppDbContextFactory
    {
        private readonly ApplicationConfiguration _configuration;

        public AppDbContextFactory(ApplicationConfiguration configuration)
            => _configuration = configuration;

        public DbContextOptions<AppDbContext> CreateOptions()
        {
            if (_configuration.Database is null)
                throw new InvalidOperationException("Banco não configurado.");

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            switch (_configuration?.Database?.Provider)
            {
                case EDatabaseProvider.SQLite:
                    builder.UseSqlite(_configuration.Database.ConnectionString);
                    break;

                case EDatabaseProvider.PostgreSql:
                    builder.UseNpgsql(_configuration.Database.ConnectionString);
                    break;

                default:
                    throw new NotSupportedException("Banco não suportado.");
            }

            return builder.Options;
        }
    }
}