using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.Task;

namespace ToDoList.Core.Interfaces.Repositories
{
    public interface ITasksRepository
    {
        Task<ResponseDTO> CreateTask(CreateTaskDTO taskDTO);
        Task<ResponseDTO> UpdateTask(UpdateTaskDTO taskDTO);
        Task<ResponseDTO> DeleteTask(int idTask);
        Task<ResponseDTO> GetTaskById(int idTask);
        Task<ResponseDTO> GetAllTasks(PaginatorDTO paginator, int idUser, bool? isCompleted = null);
    }
}
