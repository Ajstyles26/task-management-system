using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Models;
using TaskManagementApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // Ensures authentication is required for all routes in this controller
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync(); // Uses async Task from System.Threading.Tasks
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskManagementApi.Models.Task task)
        {
            if (task == null)
                return BadRequest("Invalid task data");

            var createdTask = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetAllTasks), new { id = createdTask.Id }, createdTask);
        }
    }
}
