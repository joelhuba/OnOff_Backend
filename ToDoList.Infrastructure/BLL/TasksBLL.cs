    using System.Reflection;
    using ToDoList.Core.DTOs.Commons;
    using ToDoList.Core.DTOs.Task;
    using ToDoList.Core.Interfaces.BLL;
    using ToDoList.Core.Interfaces.Repositories;
    using ToDoList.Core.Interfaces.Services;
    using ToDoList.Infrastructure.Helpers;

    namespace ToDoList.Infrastructure.BLL
    {
        public class TasksBLL(ITasksRepository tasksRepository,ILogServices logServices) : ITasksBLL
        {
            private readonly ITasksRepository _tasksRepository = tasksRepository;
            private readonly ILogServices _logServices = logServices;
            public async Task<ResponseDTO> CreateTask(CreateTaskDTO taskDTO)
            {
                try
                {
                    return await _tasksRepository.CreateTask(taskDTO);
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
                    return await _tasksRepository.DeleteTask(idTask);
                }
                catch (Exception ex)
                {
                    return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
                }
            }

            public async Task<ResponseDTO> GetAllTasks(PaginatorDTO paginator, int idUser , bool? isCompleted = null)
            {
                try
                {
                    return await _tasksRepository.GetAllTasks(paginator, idUser, isCompleted);
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
                    return await _tasksRepository.GetTaskById(idTask);
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
                    return await _tasksRepository.UpdateTask(taskDTO);
                }
                catch (Exception ex)
                {
                    return ExceptionHelper.HandleException(_logServices, MethodBase.GetCurrentMethod().Name, ex);
                }
            }
        }
    }
