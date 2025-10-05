using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.Interfaces.BLL;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Helpers;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthBLL authBLL,ILogServices logServices) : ControllerBase
    {
        private readonly IAuthBLL _authBLL = authBLL;
        private readonly ILogServices _logServices = logServices;
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(AuthDTO authDTO) => await HandleResponses.HandleResponse(() => _authBLL.Auth(authDTO), _logServices, nameof(Login));
    }
}
