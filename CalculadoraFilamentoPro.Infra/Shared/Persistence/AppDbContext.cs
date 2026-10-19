using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}