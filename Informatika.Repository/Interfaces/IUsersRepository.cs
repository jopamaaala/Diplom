using Informatika.Domain.Models;

namespace Informatika.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<List<User>> GetListAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task UpdateUserAsync(User user);
    }
}
