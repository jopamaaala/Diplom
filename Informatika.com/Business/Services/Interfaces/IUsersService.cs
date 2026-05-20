using Informatika.Application.Models;
using Informatika.Domain.Models;

namespace Informatika.Application.Business.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string Username);
        Task<ServiceResponse<string>> LoginAsync(UserLoginRequest model);
        Task<ServiceResponse<string>> RegisterAsync(UserRegisterRequest model);
    }
}