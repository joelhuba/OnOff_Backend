using System.ComponentModel.DataAnnotations;

namespace ToDoList.Core.DTOs.Task
{
    public class TaskDTO
    {
        public int IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public int UserId { get; set; }
    }
    public class CreateTaskDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public int IdUser { get; set; }
    }

    public class UpdateTaskDTO
    {
        [Required]
        public int IdTask { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
