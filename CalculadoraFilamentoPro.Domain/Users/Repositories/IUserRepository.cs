using CalculadoraFilamentoPro.Domain.Users.Entities;

namespace CalculadoraFilamentoPro.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> FindByEmailAsync(string email);

    Task<User?> GetByIdAsync(Guid id);

    Task SaveAsync(User user);
}
