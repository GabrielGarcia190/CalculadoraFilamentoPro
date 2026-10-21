using CalculadoraFilamentoPro.Domain.Users.Entities;

namespace CalculadoraFilamentoPro.Domain.Users.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<User?> FindByUserNameAsync(string userName);

    Task<User?> GetByIdAsync(Guid id);

    Task SaveAsync(User user);
}
