using TaskManagementApi.Models;
using TaskManagementApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; // For asynchronous tasks
using TaskManagementApi.Models; // For your custom Task model


namespace TaskManagementApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskManagementApi.Models.Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();  // Use fully qualified name for custom Task
        }

        public async Task<TaskManagementApi.Models.Task> CreateTaskAsync(TaskManagementApi.Models.Task task)  // Fully qualified name
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}