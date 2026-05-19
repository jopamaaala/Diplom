using Informatika.Application.Models;
using Informatika.Domain.Models;

namespace Informatika.Application.Services
{
    public interface IUsersService
    {
        Task<List<User>?> GetAllUsersAsync();
        Task<User?> GetEmailAsync(string email);
        Task<User?> GetUserAsync(Guid id);
        Task<ServiceResponce<User>> LoginAsync(UserLoginRequest model, HttpContext context);
        Task<ServiceResponce<User>> RegisterAsync(UserRegisterRequest model, HttpContext context);
    }
}