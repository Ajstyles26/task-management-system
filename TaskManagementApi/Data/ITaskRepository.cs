using TaskManagementApi.Models;
using System.Collections.Generic;
using Task = TaskManagementApi.Models.Task;

namespace TaskManagementApi.Data.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int id);
        Task CreateTask(Task task);
        Task UpdateTask(Task task);
        Task DeleteTask(int id);
    }
}
