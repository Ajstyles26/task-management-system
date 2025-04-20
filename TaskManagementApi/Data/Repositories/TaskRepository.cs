using TaskManagementApi.Models;
using TaskManagementApi.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task = TaskManagementApi.Models.Task;

namespace TaskManagementApi.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.User).ToList();
        }

        public Task GetTaskById(int id)
        {
            return _context.Tasks.Include(t => t.User).FirstOrDefault(t => t.Id == id);
        }

        public Task CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public Task UpdateTask(Task task)
        {
            var existingTask = _context.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            _context.SaveChanges();

            return existingTask;
        }

        public Task DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return task;
        }
    }
}
