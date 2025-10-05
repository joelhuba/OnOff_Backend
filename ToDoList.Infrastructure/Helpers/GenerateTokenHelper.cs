using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs.User;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Infrastructure.Helpers
{
    public static class GenerateTokenHelper
    {

        public static async Task<string> GenerateTokenAsync(UserDTO user, string signature, int hours, ILogServices logService)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(signature))
            {
                string response = "El nombre de usuario y la firma no pueden estar vacíos.";
                logService.SaveLogsMessages(response);
                throw new ArgumentException(response);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("IdUser", user.IdUser.ToString()),
                new Claim("Rol",user.Rol.ToString()),
                new Claim("Email",user.Email), 
                new Claim("Name",user.FirstName),
                new Claim("LastName",user.LastName),
            }),
                Expires = DateTime.UtcNow.AddHours(hours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                string response = "Error al crear el token JWT. " + ex;
                logService.SaveLogsMessages(response);
                throw new InvalidOperationException(response);
            }
        }

    }
}
