using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.Task;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Helpers;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITasksBLL tasksBLL,ILogServices logServices) : ControllerBase
    {
        private readonly ITasksBLL _tasksBLL = tasksBLL;
        private readonly ILogServices _logServices = logServices;
        [HttpGet("/GetAllTasks")]
        public async Task<IActionResult> GetAllTasks([FromQuery]PaginatorDTO paginator, int idUser, bool? isCompleted = null) => await HandleResponses.HandleResponse(()=>_tasksBLL.GetAllTasks(paginator, idUser, isCompleted), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpGet("/GetTaskById")]
        public async Task<IActionResult> GetTaskById(int idTask) => await HandleResponses.HandleResponse(() => _tasksBLL.GetTaskById(idTask), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpPost("/CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskDTO taskDTO) => await HandleResponses.HandleResponse(() => _tasksBLL.CreateTask(taskDTO), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpPut("/UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDTO taskDTO) => await HandleResponses.HandleResponse(() => _tasksBLL.UpdateTask(taskDTO), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpDelete("/DeleteTask")]
        public async Task<IActionResult> DeleteTask(int idTask) => await HandleResponses.HandleResponse(() => _tasksBLL.DeleteTask(idTask), _logServices, MethodBase.GetCurrentMethod().Name);
    }
}
