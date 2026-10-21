using CalculadoraFilamentoPro.Domain.Users.Entities;
using CalculadoraFilamentoPro.Domain.Users.Repositories;
using CalculadoraFilamentoPro.Ioc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraFilamentoPro.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
            => _context = context;

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> FindByUserNameAsync(string userName)
        {
            var normalizedUserName = userName.Trim().ToLowerInvariant();

            return _context.Users.SingleOrDefaultAsync(user => user.UserName == normalizedUserName);
        }

        public Task<User?> GetByIdAsync(Guid id)
            => _context.Users.SingleOrDefaultAsync(user => user.Id == id);

        public async Task SaveAsync(User user)
            => await _context.SaveChangesAsync();
    }
}