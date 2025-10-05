using Microsoft.Extensions.Configuration;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Infrastructure.Helpers;

namespace ToDoList.Infrastructure.BLL
{
    public class AuthBLL(IAuthRepository authRepository,ILogServices logServices,IConfiguration configuration) : IAuthBLL
    {
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly ILogServices _logServices = logServices;
        private readonly IConfiguration _configuration = configuration;
        public async Task<ResponseDTO> Auth(AuthDTO authDTO)
        {
            try
            {
                var userResponse = await _authRepository.Auth(authDTO.Email);

                if (!userResponse.IsSuccess || userResponse.Data == null)
                    return new ResponseDTO
                    {
                      IsSuccess =  false,
                      Message =  "Usuario no encontrado" 
                    };

                var user = (UserDTO)userResponse.Data;
                byte[] saltBytes = Convert.FromBase64String(user.PasswordSalt);
                bool isValidPassword = PasswordHashHelper.VerifyPassword(
                    authDTO.Password,
                    user.Password,
                    saltBytes
                );

                if (!isValidPassword)
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "Contraseña incorrecta"

                    };

                string token = await GenerateTokenHelper.GenerateTokenAsync(user, _configuration["TokenSettings:SecretToken"], Convert.ToInt32(_configuration["TokenSettings:TokenExpirationHours"]),_logServices);

                return new ResponseDTO{
                  IsSuccess =  true, 
                  Message =  "Autenticación correcta", 
                  Data = new { Token = token } };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
