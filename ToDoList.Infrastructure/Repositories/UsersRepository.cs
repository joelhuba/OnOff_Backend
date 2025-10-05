using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Repositories.DataContext;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Infrastructure.Helpers;

namespace ToDoList.Infrastructure.Repositories
{
    public class UsersRepository(IDataContext dataContext,ILogServices logServices) : IUsersRepository
    {
        private readonly IDataContext _dataContext = dataContext;
        private readonly ILogServices _logServices = logServices;
        public async Task<ResponseDTO> CreateUser(CreateUserDTO userDTO)
        {
           
            try
            {
                var user = new UserEntity
                {
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    PasswordSalt = userDTO.PasswordSalt,
                    Rol = userDTO.Rol,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName
                };
                await _dataContext.Users.AddAsync(user);
                await _dataContext.SaveChangesAsync();
                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Usuario creado correctamente",
                    Data = user.IdUser
                };
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
                var user = await _dataContext.Users.FindAsync(idUser);
                if (user == null)
                    return new ResponseDTO{ IsSuccess = false, Message = "Usuario no encontrado" };

                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();

                return new ResponseDTO{ IsSuccess = true, Message = "Usuario eliminado correctamente" };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetAllUsers(PaginatorDTO paginatorDTO, string? email = null)
        {
            try
            {
                var query = _dataContext.Users.AsQueryable();

                if (!string.IsNullOrEmpty(email))
                    query = query.Where(u => u.Email == email);

                int total = await query.CountAsync();

                var users = await query
                    .Skip((paginatorDTO.PageIndex - 1) * paginatorDTO.PageSize)
                    .Take(paginatorDTO.PageSize)
                    .Select(u => new UserDTO
                     {
                        IdUser = u.IdUser,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Rol = u.Rol
                    })
        .ToListAsync();

                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Usuarios obtenidos correctamente",
                    Data = new { total, users }
                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        public async Task<ResponseDTO> GetUserById(int idUser)
        {
            try
            {
                var user = await _dataContext.Users
                .Where(u => u.IdUser == idUser)
                .Select(u => new UserDTO
                    {
                     IdUser = u.IdUser,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName

                })
                .FirstOrDefaultAsync();
                return user is null
                    ? new ResponseDTO
                    { 
                        IsSuccess = false, 
                        Message = "Usuario no encontrado" 
                    }
                    : new ResponseDTO
                    { 
                        IsSuccess = true, 
                        Message = "Usuario encontrado", 
                        Data = user 
                    };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateUser(UpdateUserDTO userDTO)
        {
            try
            {
                var user = await _dataContext.Users.FindAsync(userDTO.IdUser);
                if (user == null)
                    return new ResponseDTO{ IsSuccess = false, Message = "Usuario no encontrado" };

                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.Email = userDTO.Email;
                user.Rol = userDTO.Rol;

                _dataContext.Users.Update(user);
                await _dataContext.SaveChangesAsync();

                return new ResponseDTO {IsSuccess = true,Message = "Usuario actualizado correctamente" };
            }
            catch(Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
