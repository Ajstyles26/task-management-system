using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public interface IAuthService
    {
        User ValidateUser(string email, string password);
        User RegisterUser(string email, string password);
    }
}
