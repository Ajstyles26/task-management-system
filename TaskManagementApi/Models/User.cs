namespace TaskManagementApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // Password hash for security
        public ICollection<Task> Tasks { get; set; }  // Navigation property (One-to-Many relationship)
    }
}
