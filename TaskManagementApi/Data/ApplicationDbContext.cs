using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;  // Keep this for your Task and User models

namespace TaskManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define the DbSets (tables) for the application
        public DbSet<User> Users { get; set; }
        public DbSet<TaskManagementApi.Models.Task> Tasks { get; set; }  // Fully qualified Task name

        // Optionally override OnModelCreating if you want to configure relationships, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: Configure a one-to-many relationship between User and Task
            modelBuilder.Entity<TaskManagementApi.Models.Task>()  // Fully qualified Task name
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
        }
    }
}
