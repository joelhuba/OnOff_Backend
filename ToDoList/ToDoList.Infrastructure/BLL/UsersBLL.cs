using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Infrastructure.Helpers;

namespace ToDoList.Infrastructure.BLL
{
    public class UsersBLL(IUsersRepository usersRepository,ILogServices logServices) : IUsersBLL
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly ILogServices _logServices = logServices;
        public async Task<ResponseDTO> CreateUser(CreateUserDTO user)
        {
            try
            {
                var (passwordHased, salt) = PasswordHashHelper.HashPassword(user.Password);
                user.Password = passwordHased;
                user.PasswordSalt = salt;
                return await _usersRepository.CreateUser(user);
            }
            catch(Exception ex)
            {
               return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> DeleteUser(int idUser)
        {
            try
            {
                return await _usersRepository.DeleteUser(idUser);
            }
            catch (Exception ex)
            {
                return (ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex));
            }
        }
        public async Task<ResponseDTO> GetAllUsers(PaginatorDTO paginatorDTO, string? email = null)
        {
            try
            {
                return await _usersRepository.GetAllUsers(paginatorDTO, email);
            }
            catch(Exception ex)
            {
                return (ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex));
            }
        }

        public async Task<ResponseDTO> GetUserById(int idUser)
        {
            try
            {
                return await _usersRepository.GetUserById(idUser);
            }
            catch(Exception ex)
            {
                return (ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex));
            }
        }

        public async Task<ResponseDTO> UpdateUser(UpdateUserDTO user)
        {
            try
            {
                return await _usersRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                return (ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex));
            }
        }
    }
}
