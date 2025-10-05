
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Core.Entities
    {
        [Table("Tasks")]
        public class TaskEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int IdTask { get; set; }

            [Required]
            [MaxLength(200)]
            public string Title { get; set; } = string.Empty;

            [MaxLength(500)]
            public string? Description { get; set; }

            public bool IsCompleted { get; set; } = false;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? CompletedAt { get; set; }

            [Required]
            [ForeignKey(nameof(User))]
            public int IdUser { get; set; }

            public UserEntity User { get; set; } = null!;
        }
    }
