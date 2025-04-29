using System.ComponentModel.DataAnnotations;

namespace TaskPulse.Service.Models
{
    public class AddTaskDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
    }
}
