using CalculadoraFilamentoPro.Domain.Filaments.Entities;
using CalculadoraFilamentoPro.Domain.Filaments.Repositories;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Infra.Filaments
{
    public class FilamentRepository : IFilamentRepository
    {
        private readonly AppDbContext _context;

        public FilamentRepository(AppDbContext context)
            => _context = context;

        public async Task AddAsync(Filament filament)
        {
            await _context.Filaments.AddAsync(filament);
            await _context.SaveChangesAsync();
        }

        public async Task<Filament?> FindByIdAsync(Guid id)
            => await _context.Filaments.FindAsync(id);

        public async Task<IEnumerable<Filament>> GetFilamentsByUsersAsync(Guid userId)
            => await _context.Filaments.Where(f => f.UserId == userId).ToListAsync();

        public async Task SaveAsync(Filament filament)
        {
            _context.Filaments.Update(filament);
            await _context.SaveChangesAsync();
        }
    }
}
