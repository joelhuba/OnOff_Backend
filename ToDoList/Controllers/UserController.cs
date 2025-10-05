using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Helpers;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUsersBLL usersBLL,ILogServices logServices) : ControllerBase
    {
        private readonly IUsersBLL _usersBLL = usersBLL;
        private readonly ILogServices _logServices = logServices;
        [HttpGet("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery]PaginatorDTO paginatorDTO, string? email = null) =>await HandleResponses.HandleResponse(() => _usersBLL.GetAllUsers(paginatorDTO, email), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpGet("/GetUserById")]
        public async Task<IActionResult> GetUserById(int idUser) => await HandleResponses.HandleResponse(() => _usersBLL.GetUserById(idUser), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserDTO user) => await HandleResponses.HandleResponse(() => _usersBLL.CreateUser(user), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> DeleteUser(int idUser) => await HandleResponses.HandleResponse(() => _usersBLL.DeleteUser(idUser), _logServices, MethodBase.GetCurrentMethod().Name);
        [HttpPut("/UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDTO user) => await HandleResponses.HandleResponse(() => _usersBLL.UpdateUser(user), _logServices, MethodBase.GetCurrentMethod().Name);

    }
}
