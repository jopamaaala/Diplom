using Informatika.Database;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Informatika.Repository.Repositories
{

    public class UsersRepository : IUsersRepository
    {
        private readonly InformatikaDbContext _context;

        public UsersRepository(InformatikaDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users
                .Remove(user);

            await _context
                .SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users
                .Add(user);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users
                .Update(user);

            await _context
                .SaveChangesAsync();
        }
    }
}
