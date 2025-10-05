using ToDoList.Core.DTOs.Commons;

namespace ToDoList.Core.Interfaces.BLL
{
    public interface IAuthBLL
    {
        public Task<ResponseDTO> Auth(AuthDTO authDTO);
    }
}
