using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Repositories.DataContext;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Infrastructure.Helpers;

namespace ToDoList.Infrastructure.Repositories
{
    public class AuthRepository(IDataContext dataContext, ILogServices logServices) : IAuthRepository
    {
        private readonly IDataContext _dataContext = dataContext;
        private readonly ILogServices _logServices = logServices;
        public async Task<ResponseDTO> Auth(string email)
        {
            try
            {
                var user = await _dataContext.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

                if (user == null)
                {
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "Usuario no encontrado."
                    };
                }
                var userData = new UserDTO
                {
                    IdUser = user.IdUser,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Rol = user.Rol,
                    Password = user.Password,
                    PasswordSalt = user.PasswordSalt
                };

                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Usuario encontrado correctamente.",
                    Data = userData
                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
