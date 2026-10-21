using CalculadoraFilamentoPro.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<User>();

        user.HasIndex(entity => entity.UserName)
            .IsUnique();

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            user.Property(entity => entity.Id)
                .HasDefaultValueSql("lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))), 2) || '-' || substr('89ab', abs(random()) % 4 + 1, 1) || substr(lower(hex(randomblob(2))), 2) || '-' || lower(hex(randomblob(6)))");
            user.Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        else if (Database.ProviderName == "Npgsql.EntityFrameworkCore.PostgreSQL")
        {
            user.Property(entity => entity.Id)
                .HasDefaultValueSql("gen_random_uuid()");
            user.Property(entity => entity.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        base.OnModelCreating(modelBuilder);
    }
}