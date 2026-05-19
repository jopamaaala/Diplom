using Informatika.Application.Business.Helpers;
using Informatika.Application.Models;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Informatika.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<List<User>?> GetAllUsersAsync()
        {
            try
            {
                return await _usersRepository.GetListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            try
            {
                return await _usersRepository.GetUserByIdAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetEmailAsync(string email)
        {
            try
            {
                return await _usersRepository.GetUserByEmailAsync(email);

            }
            catch
            {
                return null;
            }
        }

        public async Task<ServiceResponce<User>> RegisterAsync(UserRegisterRequest model, HttpContext context)
        {
            try
            {
                if (model.Password != model.ConfirmPassword)
                {
                    return new ServiceResponce<User>
                    {
                        Error = "Введёные пароли не совпадают!"
                    };
                }

                var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password);
                var user = new User
                {
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username
                };

                await _usersRepository.AddUserAsync(user);

                return await LoginAsync(new UserLoginRequest
                { Email = model.Email, Username = model.Username, Password = model.Password }, context);
            }
            catch
            {
                return new ServiceResponce<User>
                {
                    Error = "Пользователь с такой почтой или именем уже существует"
                };
            }
        }

        public async Task<ServiceResponce<User>> LoginAsync(UserLoginRequest model, HttpContext context)
        {
            try
            {
                var user = await _usersRepository.GetUserByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.PasswordHash);

                    if (result)
                    {
                        var token = _jwtProvider.GenerateToken(user);
                        return new ServiceResponce<User>
                        {
                            Success = true,
                            Data = user
                        };
                    }

                    return new ServiceResponce<User>
                    {
                        Success = false,
                        Error = "Во время авторизации произошла ошибка, попробуйте ещё раз"
                    };
                }

                return new ServiceResponce<User>
                {
                    Success = false,
                    Error = "Почта или пароль введены не верно"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponce<User>
                {
                    Succes = false,
                    Error = ex.Message
                };
            }
        }


    }
}
