using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoList.Controllers;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.Task;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Test
{
    public class TasksControllerTests
    {
        private readonly Mock<ITasksBLL> _mockTasksBLL;
        private readonly Mock<ILogServices> _mockLogServices;
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
            _mockTasksBLL = new Mock<ITasksBLL>();
            _mockLogServices = new Mock<ILogServices>();
            _controller = new TasksController(_mockTasksBLL.Object, _mockLogServices.Object);
        }

        [Fact]
        public async Task GetAllTasks_ReturnsOkResult_WithResponseDTO()
        {

            var paginator = new PaginatorDTO { PageIndex = 1, PageSize = 10 };
            var response = new ResponseDTO { IsSuccess = true, Message = "Ok" };
            _mockTasksBLL.Setup(x => x.GetAllTasks(paginator, 2, null)).ReturnsAsync(response);

            var result = await _controller.GetAllTasks(paginator,2);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<ResponseDTO>(okResult.Value);
            Assert.True(dto.IsSuccess);
        }

        [Fact]
        public async Task GetTaskById_ReturnsOkResult_WithResponseDTO()
        {
            var response = new ResponseDTO { IsSuccess = true, Message = "Ok" };
            _mockTasksBLL.Setup(x => x.GetTaskById(1)).ReturnsAsync(response);

            var result = await _controller.GetTaskById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<ResponseDTO>(okResult.Value);
            Assert.True(dto.IsSuccess);
        }

        [Fact]
        public async Task CreateTask_ReturnsOkResult_WithResponseDTO()
        {
            var taskDTO = new CreateTaskDTO { Title = "Test Task", Description = "Test" };
            var response = new ResponseDTO { IsSuccess = true, Message = "Created" };
            _mockTasksBLL.Setup(x => x.CreateTask(taskDTO)).ReturnsAsync(response);

            var result = await _controller.CreateTask(taskDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<ResponseDTO>(okResult.Value);
            Assert.True(dto.IsSuccess);
        }

        [Fact]
        public async Task UpdateTask_ReturnsOkResult_WithResponseDTO()
        {
            var taskDTO = new UpdateTaskDTO { IdTask = 1, Title = "Updated Task", Description = "Updated" };
            var response = new ResponseDTO { IsSuccess = true, Message = "Updated" };
            _mockTasksBLL.Setup(x => x.UpdateTask(taskDTO)).ReturnsAsync(response);

            var result = await _controller.UpdateTask(taskDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<ResponseDTO>(okResult.Value);
            Assert.True(dto.IsSuccess);
        }

        [Fact]
        public async Task DeleteTask_ReturnsOkResult_WithResponseDTO()
        {
            var response = new ResponseDTO { IsSuccess = true, Message = "Deleted" };
            _mockTasksBLL.Setup(x => x.DeleteTask(1)).ReturnsAsync(response);

            var result = await _controller.DeleteTask(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<ResponseDTO>(okResult.Value);
            Assert.True(dto.IsSuccess);
        }
    }
}
