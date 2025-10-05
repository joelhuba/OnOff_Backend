using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.Task;

namespace ToDoList.Core.Interfaces.BLL
{
    public interface ITasksBLL
    {
        Task<ResponseDTO> CreateTask(CreateTaskDTO taskDTO);
        Task<ResponseDTO> UpdateTask(UpdateTaskDTO taskDTO);
        Task<ResponseDTO> DeleteTask(int idTask);
        Task<ResponseDTO> GetTaskById(int idTask);
        Task<ResponseDTO> GetAllTasks(PaginatorDTO paginator, int idUser , bool? isCompleted = null);
    }
}
