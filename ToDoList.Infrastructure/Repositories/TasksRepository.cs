using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.Task;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Repositories.DataContext;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Infrastructure.Helpers;

namespace ToDoList.Infrastructure.Repositories
{
    public class TasksRepository(IDataContext dataContext, ILogServices logServices) : ITasksRepository
    {
        private readonly IDataContext _dataContext = dataContext;
        private readonly ILogServices _logServices = logServices;

        public  async Task<ResponseDTO> CreateTask(CreateTaskDTO taskDTO)
        {
            try
            {
                var task = new TaskEntity
                {
                    Title = taskDTO.Title,
                    Description = taskDTO.Description,
                    IdUser = taskDTO.IdUser,
                    CreatedAt = DateTime.UtcNow,
                    IsCompleted = false
                };

                await _dataContext.Tasks.AddAsync(task);
                await _dataContext.SaveChangesAsync();

                return new ResponseDTO { IsSuccess = true, Message = "Tarea creada correctamente",Data = null };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateTask(UpdateTaskDTO taskDTO)
        {
            try
            {
                var task = await _dataContext.Tasks.FindAsync(taskDTO.IdTask);
                if (task == null)
                    return new ResponseDTO {IsSuccess = false, Message = "Tarea no encontrada" };

                task.Title = taskDTO.Title;
                task.Description = taskDTO.Description;
                task.IsCompleted = taskDTO.IsCompleted;
                task.CompletedAt = taskDTO.IsCompleted ? DateTime.UtcNow : null;

                _dataContext.Tasks.Update(task);
                await _dataContext.SaveChangesAsync();

                return new ResponseDTO { IsSuccess = true, Message = "Tarea actualizada correctamente" };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> DeleteTask(int idTask)
        {
            try
            {
                var task = await _dataContext.Tasks.FindAsync(idTask);
                if (task == null)
                    return new ResponseDTO{ IsSuccess = false, Message = "Tarea no encontrada" };

                _dataContext.Tasks.Remove(task);
                await _dataContext.SaveChangesAsync();

                return new ResponseDTO{ IsSuccess = true, Message = "Tarea eliminada correctamente" };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetTaskById(int idTask)
        {
            try
            {
                var task = await _dataContext.Tasks.FindAsync(idTask);
                return task == null
                    ? new ResponseDTO{ IsSuccess = false, Message = "Tarea no encontrada" }
                    : new ResponseDTO { IsSuccess = true, Message = "Tarea obtenida correctamente", Data = null };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetAllTasks(PaginatorDTO paginator, int idUser, bool? isCompleted = null)
        {
            try
            {
                var query = _dataContext.Tasks.AsQueryable();

                // Filtrar por usuario obligatorio
                query = query.Where(t => t.IdUser == idUser);

                // Filtrar por estado si se proporciona
                if (isCompleted.HasValue)
                    query = query.Where(t => t.IsCompleted == isCompleted.Value);

                int total = await query.CountAsync();

                var tasks = await query
                    .OrderByDescending(t => t.CreatedAt)
                    .Skip((paginator.PageIndex - 1) * paginator.PageSize)
                    .Take(paginator.PageSize)
                    .ToListAsync();

                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Tareas obtenidas correctamente",
                    Data = tasks
                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
