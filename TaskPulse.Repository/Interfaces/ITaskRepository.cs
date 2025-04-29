namespace TaskPulse.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Entities.Task>> GetTasks();
        Task<Entities.Task> AddTask(Entities.Task task);
    }
}
