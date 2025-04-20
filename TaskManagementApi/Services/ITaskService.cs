using TaskManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks; // For asynchronous tasks
using TaskManagementApi.Models; // For your custom Task model

namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskManagementApi.Models.Task>> GetAllTasksAsync();  // Fully qualified name
        Task<TaskManagementApi.Models.Task> CreateTaskAsync(TaskManagementApi.Models.Task task);  // Fully qualified name
    }
}
