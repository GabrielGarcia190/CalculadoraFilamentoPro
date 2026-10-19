using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraFilamentoPro.Infra.Shared.Persistence
{
    public class AppDbContextFactory
    {
        private readonly IConfigurationRepository _repository;

        public AppDbContextFactory(IConfigurationRepository repository)
            => _repository = repository;

        public async Task<AppDbContext> CreateAsync()
        {
            var configuration = await _repository.GetConnectionStringAsync();

            if (configuration == null)
                throw new InvalidOperationException("Banco não configurado.");

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            switch (configuration.Provider)
            {
                case EDatabaseProvider.SQLite:
                    builder.UseSqlite(configuration.ConnectionString);
                    break;

                case EDatabaseProvider.PostgreSql:
                    builder.UseNpgsql(configuration.ConnectionString);
                    break;

                default:
                    throw new NotSupportedException(
                        $"Banco {configuration.Provider} não suportado."
                    );
            }

            return new AppDbContext(builder.Options);
        }
    }
}