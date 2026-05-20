using Informatika.Application.Business.Helpers;
using Informatika.Application.Business.Services.Interfaces;
using Informatika.Application.Models.Requests;
using Informatika.Domain.Models;
using Informatika.Repository.Interfaces;
using Microsoft.AspNetCore.Connections.Features;
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

        public async Task<User?> GetByUsernameAsync(string Username)
        {
            try
            {
                return await _usersRepository.GetUserByUsernameAsync(Username);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
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

        public async Task<ServiceResponse<string>> RegisterAsync(UserRegisterRequest model)
        {
            try
            {
                if (model.Password != model.ConfirmPassword)
                {
                    return new ServiceResponse<string>
                    {
                        Error = "Введёные пароли не совпадают!"
                    };
                }

                if (await GetByEmailAsync(model.Email) != null)
                {
                    return new ServiceResponse<string>
                    {
                        Error = "Пользователь с такой почтой уже существует"
                    };
                }
                else if (await GetByUsernameAsync(model.Username) != null)
                {
                    return new ServiceResponse<string>
                    {
                        Error = "Пользователь с таким именем пользователя уже существует"
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

                return await LoginAsync(new UserLoginRequest { Email = model.Email, Username = model.Username, Password = model.Password });
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>
                {
                    Error = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<string>> LoginAsync(UserLoginRequest model)
        {
            try
            {
                var user = await GetByEmailAsync(model.Email) ?? await GetByUsernameAsync(model.Username);

                if (user != null)
                {
                    var result = BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.PasswordHash);

                    if (result)
                    {
                        var token = _jwtProvider.GenerateToken(user);
                        return new ServiceResponse<string>
                        {
                            Success = true,
                            Data = token
                        };
                    }

                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Error = "Во время авторизации произошла ошибка, попробуйте ещё раз"
                    };
                }

                return new ServiceResponse<string>
                {
                    Success = false,
                    Error = "Почта или пароль введены не верно"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<User>> UpdateProfileAsync(UserProfileRequest request, Guid Id)
        {
            try
            {
                var user = await _usersRepository.GetUserByIdAsync(Id);

                if (user != null && await _usersRepository.GetUserByEmailAsync(request.Email) == null && await _usersRepository.GetUserByUsernameAsync(request.Username) == null)
                {
                    user.Username = request.Username;
                    user.LastName = request.LastName;
                    user.FirstName = request.FirstName;
                    user.AvatarURL = request.AvatarUrl;
                    user.Email = request.Email;

                    await _usersRepository.UpdateUserAsync(user);

                    return new ServiceResponse<User>
                    {
                        Success = true,
                        Data = user
                    };
                }

                return new ServiceResponse<User>
                {
                    Success = false,
                    Error = "Пользователь не найден"
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<User>
                {
                    Success= false,
                    Error = ex.Message
                };

            }
        }
    }
}
