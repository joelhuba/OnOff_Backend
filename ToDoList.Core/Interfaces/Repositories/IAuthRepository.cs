using ToDoList.Core.DTOs.Commons;

namespace ToDoList.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        public Task<ResponseDTO> Auth(string email);
    }
}
