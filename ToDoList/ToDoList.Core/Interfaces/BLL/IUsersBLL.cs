using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;

namespace ToDoList.Core.Interfaces.BLL
{
    public interface IUsersBLL
    {
        Task<ResponseDTO> GetUserById(int idUser);
        Task<ResponseDTO> GetAllUsers(PaginatorDTO paginatorDTO, string? email = null);
        Task<ResponseDTO> CreateUser(UserDTO user);
        Task<ResponseDTO> UpdateUser(UserDTO user);
        Task<ResponseDTO> DeleteUser(int idUser);
    }
}
