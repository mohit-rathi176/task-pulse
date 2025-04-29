using Microsoft.AspNetCore.Mvc;
using TaskPulse.Service.Interfaces;
using TaskPulse.Service.Models;

namespace TaskPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Repository.Entities.Task>>> GetTasks()
        {
            return Ok(await _taskService.GetTasks());
        }

        [HttpPost]
        public async Task<ActionResult<Repository.Entities.Task>> AddTask([FromBody] AddTaskDto model)
        {
            return Ok(await _taskService.AddTask(model));
        }
    }
}
