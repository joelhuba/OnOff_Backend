using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Helpers
{
    public class HandleResponses
    {
        public static async Task<ActionResult> HandleResponse(Func<Task<ResponseDTO>> action, ILogServices _logService, string controllerName)
        {
            try
            {
                ResponseDTO response = await action.Invoke();

                return new OkObjectResult(response);

            }
            catch (ValidationException ex)
            {
                _logService.SaveLogsMessages($"Error desde :: {controllerName} :: {ex.Message}");
                return new BadRequestObjectResult(new ResponseDTO { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessages($"Error desde :: {controllerName} :: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}

