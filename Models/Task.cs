using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem // Asegúrate de que este nombre coincida con el que usas en las vistas
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}