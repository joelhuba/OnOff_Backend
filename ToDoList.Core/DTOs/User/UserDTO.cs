using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Rol { get; set; }
        public string Password { get; set; }
        public string? PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public string? PasswordSalt { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
    public class UpdateUserDTO
    {
        public int IdUser { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
