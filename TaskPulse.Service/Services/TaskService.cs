using TaskPulse.Repository.Interfaces;
using TaskPulse.Service.Interfaces;
using TaskPulse.Service.Models;

namespace TaskPulse.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Repository.Entities.Task>> GetTasks()
        {
            return await _taskRepository.GetTasks();
        }

        public async Task<Repository.Entities.Task> AddTask(AddTaskDto model)
        {
            var now = DateTime.UtcNow;

            var task = new Repository.Entities.Task
            {
                Title = model.Title,
                CreatedDate = now,
                ModifiedDate = now
            };

            return await _taskRepository.AddTask(task);
        }
    }
}
