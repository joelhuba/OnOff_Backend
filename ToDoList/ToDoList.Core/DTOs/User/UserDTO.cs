using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs.User
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string? PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string? PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UpdateUserDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
