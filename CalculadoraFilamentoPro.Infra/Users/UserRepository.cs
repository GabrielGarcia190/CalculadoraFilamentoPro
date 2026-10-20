using CalculadoraFilamentoPro.Domain.Users.Entities;
using CalculadoraFilamentoPro.Domain.Users.Repositories;

namespace CalculadoraFilamentoPro.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}