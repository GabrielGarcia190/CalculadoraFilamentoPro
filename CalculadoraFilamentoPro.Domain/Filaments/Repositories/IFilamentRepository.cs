using CalculadoraFilamentoPro.Domain.Filaments.Entities;

namespace CalculadoraFilamentoPro.Domain.Filaments.Repositories;

public interface IFilamentRepository
{
    Task AddAsync(Filament filament);

    Task<Filament?> FindByIdAsync(Guid id);
        
    Task SaveAsync(Filament filament);

    Task<IEnumerable<Filament>> GetFilamentsByUsersAsync(Guid userId);
}