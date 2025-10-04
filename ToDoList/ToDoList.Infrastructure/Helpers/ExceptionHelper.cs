using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs.Commons;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Infrastructure.Helpers
{
    public class ExceptionHelper
    {
        public static ResponseDTO HandleException(ILogServices logService, string methodName, Exception ex)
        {
            logService.SaveLogsMessages($"Se ha producido un error al ejecutar BLL: {methodName}: {ex.Message}");
            var response = new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
            return response;
        }
    }
}
