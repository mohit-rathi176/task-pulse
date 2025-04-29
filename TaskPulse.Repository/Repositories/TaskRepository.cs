using Microsoft.EntityFrameworkCore;
using TaskPulse.Repository.Interfaces;

namespace TaskPulse.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entities.Task>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> AddTask(Entities.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
