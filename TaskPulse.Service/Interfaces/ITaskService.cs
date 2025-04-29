using TaskPulse.Service.Models;

namespace TaskPulse.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<Repository.Entities.Task>> GetTasks();
        Task<Repository.Entities.Task> AddTask(AddTaskDto model);
    }
}
