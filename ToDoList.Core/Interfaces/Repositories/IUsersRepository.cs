using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;

namespace ToDoList.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<ResponseDTO> GetUserById(int idUser);
        Task<ResponseDTO> GetAllUsers(PaginatorDTO paginatorDTO, string? email = null);
        Task<ResponseDTO> CreateUser(CreateUserDTO user);
        Task<ResponseDTO> UpdateUser(UpdateUserDTO user);
        Task<ResponseDTO> DeleteUser(int idUser);
    }
}
